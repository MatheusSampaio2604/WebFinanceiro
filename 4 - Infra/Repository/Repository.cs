using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

namespace Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContextOptions<DataContext> _optionsBuilder;
        protected readonly DataContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(DataContext dataContext)
        {
            _optionsBuilder = new DbContextOptions<DataContext>();
            Context = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            DbSet = Context.Set<T>();
        }

        #region Disposed
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                Context.Dispose(); // Dispose the context here.
            }

            disposed = true;
        }
        #endregion

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> CreateAsync(T entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
                return await SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao adicionar o objeto.", ex);
            }
        }

        public async Task<int> EditAsync(T entity)
        {
            try
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
                return await SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao editar o objeto.", ex);
            }
        }

        public async Task<T> FindOneAsync(int id)
        {
            try
            {
                var obj = await DbSet.FindAsync(id);
                //if (Context.Entry(obj).State == EntityState.Unchanged)
                //{
                //    Context.Entry(obj).State = EntityState.Detached;
                //    obj = await DbSet.FindAsync(id);
                //}
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao Encontrar o objeto.", ex);
            }
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            try
            {
                return await DbSet.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao Carregar a lista.", ex);
            }
        }

        public async Task<int> Remove(T entity)
        {
            try
            {
                using DataContext data = new(_optionsBuilder);
                data.Set<T>().Remove(entity);
                return await data.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao remover a entidade.", ex);
            }
        }
    }
}

namespace Domain.Interfaces
{
    public interface IRepository<OBJ> : IDisposable where OBJ : class

    {

        Task<int> CreateAsync(OBJ entity);

        Task<int> EditAsync(OBJ entity);

        Task<OBJ> FindOneAsync(int id);

        Task<IEnumerable<OBJ>> FindAllAsync();

        Task<int> Remove(OBJ entity);



    }






}
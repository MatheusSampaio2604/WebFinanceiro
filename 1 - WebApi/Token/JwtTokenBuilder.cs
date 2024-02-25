using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Token
{
    public class JwtTokenBuilder
    {
        private SecurityKey? SecurityKey;
        private string Subject = "";
        private string Issuer = "";
        private string Audience = "";
        private readonly Dictionary<string, string> Claims = [];
        private int ExpiryInMinutes;

        public JwtTokenBuilder AddSecurityKey(SecurityKey securityKey)
        {
            this.SecurityKey = securityKey;
            return this;
        }
        public JwtTokenBuilder AddSubject(string subject)
        {
            this.Subject = subject;
            return this;
        }
        public JwtTokenBuilder AddIssuer(string issuer)
        {
            this.Issuer = issuer;
            return this;
        }
        public JwtTokenBuilder AddAudience(string audience)
        {
            this.Audience = audience; return this;
        }
        public JwtTokenBuilder AddClaim(string type, string value)
        {
            this.Claims.Add(type, value);
            return this;
        }
        public JwtTokenBuilder AddExpiry(int expiryInMinutes)
        {
            this.ExpiryInMinutes = expiryInMinutes;
            return this;
        }
        private void EnsureArguments()
        {
            if (this.SecurityKey == null)
                throw new ArgumentNullException("Security Key");
            if (string.IsNullOrEmpty(this.Subject))
                throw new ArgumentNullException("Subject");
            if (string.IsNullOrEmpty(this.Issuer))
                throw new ArgumentNullException("Issuer");
            if (string.IsNullOrEmpty(this.Audience))
                throw new ArgumentNullException("Audience");
        }

        public JwtToken Builder()
        {
            EnsureArguments();

            IEnumerable<Claim>? claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Sub, this.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(this.Claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                issuer: this.Issuer,
                audience: this.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(ExpiryInMinutes),
                //signingCredentials: new SigningCredentials(this.SecurityKey, SecurityAlgorithms.Aes128CbcHmacSha256)
                signingCredentials: new SigningCredentials(this.SecurityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtToken(token);
        }
    }
}
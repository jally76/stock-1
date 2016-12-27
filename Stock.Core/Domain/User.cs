using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Stock.Core.Domain
{
    public class User
    {
        public User(string email, string name, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Name = name;

            Salt = GenerateSalt();
            Password = HashPassword(password);
        }

        public Guid Id { get; set; }

        [MaxLength(254), Column(TypeName = "varchar")]
        [Required]
        public string Email { get; set; }

        [MaxLength(128), Column(TypeName = "varchar")]
        [Required]
        public string Name { get; set; }

        [MaxLength(48), Column(TypeName = "varchar")]
        [Required]
        public string Password { get; private set; }

        [MaxLength(24), Column(TypeName = "varchar")]
        [Required]
        public string Salt { get; private set; }

        public bool IsValidPassword(string password)
        {
            var hash = HashPassword(password);
            return hash == Password;
        }

        /// <summary>
        /// GenerateSalt
        /// </summary>
        /// <remarks>http://stackoverflow.com/questions/4181198/how-to-hash-a-password </remarks>
        private static string GenerateSalt()
        {
            var salt = new byte[16];

            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);

            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// HashPassword
        /// </summary>
        /// <remarks> по информации с http://stackoverflow.com/questions/4181198/how-to-hash-a-password </remarks>
        private string HashPassword(string password)
        {
            var salt = Convert.FromBase64String(Salt);

            var r = new Rfc2898DeriveBytes(password, salt, 10000);
            var hash = r.GetBytes(32);
            return Convert.ToBase64String(hash);
        }
    }
}

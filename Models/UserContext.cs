using System;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace rotating.Models {
    
    public class UserContext : DbContext {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            
        }
        public DbSet<User> users { get; set; }

        //seeding data 
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            /* Generate Password Automated */
            string password = "PertaminaRU4";
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)
            );

            /* End Generate Password Hash*/

            modelBuilder.Entity<User>().HasData(
                new User { 
                    id = 1,
                    nip = 194020001, 
                    name = "Yulianti Eka Prista",
                    email = "yulianti@pertamina.com",
                    phone = "08821389745",
                    password = hashed,
                    status = 1,
                    role = "engineer",
                    created_at = DateTime.Today,
                    updated_at = DateTime.Today
                },
                new User { 
                    id = 2,
                    nip = 194020002, 
                    name = "Pratama Edi Saputra",
                    email = "pratama@pertamina.com",
                    phone = "087985298445",
                    password = hashed,
                    status = 1,
                    role = "engineer",
                    created_at = DateTime.Today,
                    updated_at = DateTime.Today
                },
                new User { 
                    id = 3,
                    nip = 194020003, 
                    name = "Safril Sidik",
                    email = "safril@pertamina.com",
                    phone = "088213669701",
                    password = hashed,
                    status = 1,
                    role = "admin",
                    created_at = DateTime.Today,
                    updated_at = DateTime.Today
                }
            );
        }
    }
}
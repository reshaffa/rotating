using System;
using Microsoft.EntityFrameworkCore;

namespace rotating.Models {

    public class VibrationContext : DbContext {
        public VibrationContext(DbContextOptions<VibrationContext> options) : base(options)
        {
            
        }
        public DbSet<Vibration> vibrations { get; set; }
    }
}
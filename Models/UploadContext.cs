using System;
using Microsoft.EntityFrameworkCore;

namespace rotating.Models {
    public class UploadContext : DbContext {
        public UploadContext(DbContextOptions<UploadContext> options) : base(options)
        {
            
        }
        public DbSet<Upload> uploads { get; set; }
    }
}
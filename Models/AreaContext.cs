using System;
using rotating.Models;
using Microsoft.EntityFrameworkCore;

namespace rotating.Models {

    public class AreaContext : DbContext {
        public AreaContext(DbContextOptions<AreaContext> options) : base(options)
        {
            
        }

        public DbSet<Area> areas { get; set; }

        //seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Area>().HasData(
                new Area { id= 1, name = "FOC I", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 2, name = "LOC I", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 3, name = "OM 30", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 4, name = "OM KPC", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 5, name = "OM LOC II", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 6, name = "OM LOC I", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 7, name = "OM FOC I", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 8, name = "OM LPG", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 9, name = "OM FOC II", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 10, name = "OM DRUM PLAN", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 11, name = "UTL I", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 12, name = "OM DERMAGA", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 13, name = "OM UTL I", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 14, name = "OM TELUK PENYU", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 15, name = "KPC", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 16, name = "SRU", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 17, name = "LOC III", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 18, name = "UTL III", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 19, name = "LOC II", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 20, name = "AREA 05", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 21, name = "FOC II A", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 22, name = "FOC II B", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 23, name = "OM LOC III", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 24, name = "UTL II", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 25, name = "OM", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 26, name = "RFCC GTO", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 27, name = "RFCC UTL", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 28, name = "RFCC RCU", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 29, name = "RFCC LEU", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 30, name = "SRU & IPAL", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 31, name = "PLBC UTL III", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 32, name = "PLBC FOC I", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 33, name = "PLBC LN", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today },
                new Area { id= 34, name = "OM DERMAGA PLBC", area_type = 0, created_at = DateTime.Today, updated_at = DateTime.Today}
            );
        }
    }
}
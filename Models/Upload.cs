using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rotating.Models{
    public class Upload {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int id { get; set; }

        [Required]
        public string filename { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString= "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime initial_date { get; set; }
        public int last_one { get; set; }
        public int last_two { get; set; }
        public int last_three { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public int month { get; set; }
        [Required]
        public int week { get; set; }
        public int upload_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
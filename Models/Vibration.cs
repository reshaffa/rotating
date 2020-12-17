using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rotating.Models {

    public class Vibration {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int id { get; set; }
        [Required]
        public string tag_no { get; set; }
        [Required]
        public int user_id { get; set; }
        [Required]
        public int area_id { get; set; }
        [Required]
        public int upload_id { get; set; }
        public string last_date { get; set; }
        public float dvr_ob { get; set; }
        public float dvr_obv { get; set; }
        public float dvr_obh { get; set; }
        public float dvr_ib { get; set; }
        public float dvr_ibv { get; set; }
        public float dvr_ibh { get; set; }
        public float dvr_a { get; set; }
        public float dvn_ob { get; set; }
        public float dvn_obv { get; set; }
        public float dvn_obh { get; set; }
        public float dvn_ib { get; set; }
        public float dvn_ibv { get; set; }
        public float dvn_ibh { get; set; }
        public float dvn_a { get; set; }
        public float dvr_max { get; set; }
        public float dvn_max { get; set; }
        public float actual_vib { get; set; }
        public string max_level { get; set; }
        private string def_position = null;
        [DefaultValue(null)]
        public string position { get { return def_position; } set{ def_position = value; } }
        private string def_type = "-";
        [DefaultValue("-")]
        public string type { get { return def_type; } set{ def_type = value; } }
        private string def_vib_status = "-";
        [DefaultValue("-")]
        public string vib_status { get{ return def_vib_status; } set{ def_vib_status = value; } }
        private string def_acc_status = "-";
        [DefaultValue("-")]
        public string acc_status { get{ return def_acc_status; } set{ def_acc_status = value; } }
        private string def_status = "-";
        [DefaultValue("-")]
        public string status { get{ return def_status; } set{ def_status = value; } }
        private string def_indikasi = "-";
        [DefaultValue("-")]
        public string indikasi { get { return def_indikasi; } set{ def_indikasi = value; } }
        private string def_remark = "-";
        [DefaultValue("-")]
        public string remark { get { return def_remark; } set{ def_remark = value; } }
        private string def_saran = "-";
        [DefaultValue("-")]
        public string saran { get {return def_saran; } set { def_saran = value; } }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
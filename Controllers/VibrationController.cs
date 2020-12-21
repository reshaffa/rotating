using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using rotating.Models;

namespace rotating.Controllers
{
    public class VibrationController : Controller {
        /* Injection DB Reference */
        private readonly VibrationContext _db;
        private readonly AreaContext _areas;
        private readonly UploadContext _uploads;
        public VibrationController(VibrationContext db, AreaContext db_area, UploadContext db_upload)
        {
            _db = db;
            _areas = db_area;
            _uploads = db_upload;
        }
        /* End Of injection DB Reference */
        public ActionResult Index(){
            return View();
        }

        /* API REQUEST DATA */
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            return Json(new { data = await _uploads.uploads.ToListAsync()});
        }

        [HttpPost]
        public ActionResult Create(Vibration vibration){
            var name = "FOC I";
            var upload = _uploads.uploads.FromSqlRaw("EXECUTE dbo.get_three_weeks").ToList();
            var area = _areas.areas.FromSqlInterpolated($"EXECUTE dbo.get_area_by_name {name}").ToList();
            var area_id = area[0].id;

            var last_one = 0;
            var last_two = 0;
            var last_three = 0;

            switch (upload.Count)
            {
                case 3 : 
                    last_three = upload[2].id;
                    last_two = upload[1].id;
                    last_one = upload[0].id;
                break;
                case 2 : 
                    last_three = 0;
                    last_two = upload[1].id;
                    last_one = upload[0].id;
                break;
                case 1 : 
                    last_three = 0;
                    last_two = 0;
                    last_one = upload[0].id;
                break;
                default:
                    last_one = 0;
                    last_two = 0;
                    last_three = 0;
                break;
            }
            /*
            var _uploaded_data = new Upload();
            _uploaded_data.filename = vibration.uploads.filename;
            _uploaded_data.initial_date = vibration.uploads.initial_date;
            _uploaded_data.last_one = last_one;
            _uploaded_data.last_two = last_two;
            _uploaded_data.last_three = last_three;
            _uploaded_data.year = vibration.uploads.year;
            _uploaded_data.month = vibration.uploads.month;
            _uploaded_data.week = vibration.uploads.week;
            _uploaded_data.upload_type = 1;
            _uploaded_data.created_at = DateTime.Now;
            _uploaded_data.updated_at = DateTime.Now;

            _uploads.uploads.Add(_uploaded_data);
            await _uploads.SaveChangesAsync();
            */
            return Json( new {
                success = true,
                message = "Success added new file...!"
            });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id){
            var upload_exists = await _db.vibrations.FirstOrDefaultAsync(e => e.id == id);
            if(upload_exists == null){
                return Json( new {
                    status = false,
                    message = "Error Deleted Vibrations !"
                });
            }

            _db.Remove(upload_exists);
            await _db.SaveChangesAsync();
            return Json( new {
                success = true,
                message = "Success Deleted Vibrations !"
            });
        }
    }
}


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public ActionResult Create(string filename, DateTime initial_date, int year, int month, int week, DateTime created_at, DateTime updated_at){
            
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
            var uploading = new Upload(){
                filename = filename,
                initial_date = initial_date,
                upload_type = 1,
                last_one = last_one,
                last_two = last_two,
                last_three = last_three,
                year = year,
                month = month,
                week = week,
                created_at = created_at,
                updated_at = updated_at
            };

            _uploads.uploads.Add(uploading);
            _uploads.SaveChanges();
            return Json( new {
                success = true,
                message = "Success upload and fetch data vibration...!"
            });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id){
            var upload_exists = await _uploads.uploads.FirstOrDefaultAsync(e => e.id == id);
            if(upload_exists == null){
                return Json( new {
                    status = false,
                    message = "Error Deleted Vibrations !"
                });
            }

            _uploads.Remove(upload_exists);
            await _uploads.SaveChangesAsync();
            return Json( new {
                success = true,
                message = "Success Deleted Vibrations !"
            });
        }
    }
}


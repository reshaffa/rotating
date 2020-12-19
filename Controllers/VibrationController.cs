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
        public VibrationController(VibrationContext db)
        {
            _db = db;
        }
        /* End Of injection DB Reference */
        public ActionResult Index(){
            return View();
        }

        /* API REQUEST DATA */
        [HttpGet]
        public async Task<ActionResult> GetAll(){
            return Json(new { data = await _db.vibrations.ToListAsync()});
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

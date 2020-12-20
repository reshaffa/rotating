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
    public class AreaController : Controller {
        /* Injection DB Reference */
        private readonly AreaContext _db;
        public AreaController(AreaContext db)
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
            return Json(new { data = await _db.areas.ToListAsync()});
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [Bind("name","area_type","created_at","updated_at")]
            Area areas)
        {
            if (ModelState.IsValid)
            {
                 _db.areas.Add(areas);
                await _db.SaveChangesAsync();
                return Json(new
                {
                    success = true,
                    message = "Success added new user account..!"
                });
            }
            return Json(new
            {
                success = false,
                message = "Failed added new user account..!"
            });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id){
            var upload_exists = await _db.areas.FirstOrDefaultAsync(e => e.id == id);
            if(upload_exists == null){
                return Json( new {
                    status = false,
                    message = "Error Deleted Users !"
                });
            }

            _db.Remove(upload_exists);
            await _db.SaveChangesAsync();
            return Json( new {
                success = true,
                message = "Success Deleted Users !"
            });
        }
    }
}

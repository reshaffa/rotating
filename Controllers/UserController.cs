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
    public class UserController : Controller {
        /* Injection DB Reference */
        private readonly UserContext _db;
        public UserController(UserContext db)
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
            return Json(new { data = await _db.users.ToListAsync()});
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [Bind("nip","name","email","password","phone","status","role","created_at","updated_at")] 
            User users
        )
        {
            if(ModelState.IsValid){
                _db.users.Add(users);
                await _db.SaveChangesAsync();
                return Json( new {
                    success = true,
                    message = "Success added new users..!"
                });
            }
            
            return Json( new {
                success = false,
                message = "Failed to added new users..!"
            });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id){
            var upload_exists = await _db.users.FirstOrDefaultAsync(e => e.id == id);
            if(upload_exists == null){
                return Json( new {
                    success = false,
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

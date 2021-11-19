using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace WebBase.Controllers
{
    public class SlotsController : Controller
    {
        private SchoolContext _context;

        public SlotsController(SchoolContext context)
        {
            _context = context;
        }
        
        private async Task<IActionResult> viewSetup()
        {
            ViewBag.students = await _context.Students.ToArrayAsync();
            ViewBag.length = _context.Students.ToArray().Length;
            return null;
        }

        // GET: Slots
        public async Task<IActionResult> Index()
        {
            //TODO replace with something else?
            await viewSetup();
            return View(await _context.Slots.ToListAsync());
        }  
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetSchedule()
        {
            //find the current user in the db
            //get all the slots belonging to that user
            Student temp = await _context.Students.FindAsync(User);
            Slot[] slots = temp.Slots.ToArray();
            
            
            //build json from slots
           // string jsonString = "{{";
            //foreach (Slot slt in slots)
            //{
              //  jsonString += "day:" + " \"" + slt.day + "\""
                //    + "time:" + " \"" + slt.time + "\""
                  //  + "open:" + " \"" + slt.open + "\"},";
            //}
            //jsonString += "}";            

            //return some json from the database
            //return Content(jsonString);

            //might be a fast easy way to do all the above
            return Content (Json(slots).ToString());
            

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //takes a list of times in json format and inputs them into the database for the current user
        public async Task<IActionResult> SetSchedule(JsonResult times)
        {

            //what to return?
            // return Content(Json(slots).ToString());
            return null;

        }
    }
}

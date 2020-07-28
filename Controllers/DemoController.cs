using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DropDownExaple.Data;
using DropDownExaple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace DropDownExaple.Controllers
{
    public class DemoController : Controller
    {
        private readonly AllSampleCodeContext _context;

        public DemoController(AllSampleCodeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CountryMaster> countryList = new List<CountryMaster>();

            // -- Gettin data from Database Using EntityFrameworkCore ---
            countryList = (from product in _context.CountryMaster
                           select product).ToList();

            // -- Inserting Select Item in List -------
            countryList.Insert(0, new CountryMaster { ID = 0, Name = "Select" });

            //-- Assigning country list to ViewBag.ListofCountry --------
            ViewBag.ListOfCountry = countryList;
            return View();
        }

        [HttpPost]
        public IActionResult Index(CountryMaster CountryMaster)
        {
            //-- validation -------//
            if(CountryMaster.ID == 0 )
            {
                ModelState.AddModelError("","Select Country");
            }


            //---- Getting Selected Value
            int SelectedValue = CountryMaster.ID;
            ViewBag.SelectedValue = CountryMaster.ID;

            //--- Setting Data back to ViewBag after Posting Form ---

            List<CountryMaster>countryList = new List<Models.CountryMaster>();

            countryList = (from product in _context.CountryMaster 
                            select product).ToList();

            countryList.Insert(0, new CountryMaster {ID = 0, Name = "Select"});
            ViewBag.ListofCountry = countryList;

            return View();
        }
    }
}

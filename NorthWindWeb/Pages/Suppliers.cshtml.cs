using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Packt.CS7;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        public IEnumerable<string> Suppliers { get; set; }

        //Reference to Database Context
        public Northwind db;

        [BindProperty]
        public Supplier Supplier { get; set; }

        //Constructor
        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }


        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";

            //Suppliers = new[]
            // { "Alpha Co", "Beta Limited", "Gamma Corp" };

            //Populate from Database
            Suppliers = db.Suppliers.Select(s => s.CompanyName).ToArray();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/Suppliers");

            }

            return Page();
        }
    }
}
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Packt.CS7;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages
{
    public class ShipperModel : PageModel
    {
        public IEnumerable<string> Shipper { get; set; }

        //Reference to Database Context
        public Northwind db;



        //Constructor
        public ShipperModel(Northwind injectedContext)
        {
            db = injectedContext;
        }


        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Shippers";

            //Suppliers = new[]
            // { "Alpha Co", "Beta Limited", "Gamma Corp" };

            //Populate from Database
            Shipper = db.Shippers.Select(s => s.CompanyName).ToArray();
        }


    }
}
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Packt.CS7;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages
{
    public class ProductsModel : PageModel
    {
        public IEnumerable<string> Products { get; set; }

        //Reference to Database Context
        public Northwind db;

        

        //Constructor
        public ProductsModel(Northwind injectedContext)
        {
            db = injectedContext;
        }


        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Products";

            //Suppliers = new[]
            // { "Alpha Co", "Beta Limited", "Gamma Corp" };

            //Populate from Database
            Products = db.Products.Select(s => s.ProductName).ToArray();
        }

      
        }
    }

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Bakery.DataAccess;
using Razor_Bakery.entities;

namespace Razor_Bakery.Pages
{
    public class IndexModel : PageModel
    {
        // Custom code here

        private readonly DataContext _context;
        public IndexModel(DataContext _context) => this._context = _context;
        public List<Product> Products { get; set; } = new();
        public Product FeaturedProduct { get; set; }
        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
            FeaturedProduct = Products.ElementAt(new Random().Next(Products.Count));
        }

        // End of custom code

        private readonly ILogger<IndexModel> _logger;

        // Had to comment this out to fix an error.
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        // Had to comment this out to fix an error.
        //public void OnGet()
        //{

        //}
    }
}

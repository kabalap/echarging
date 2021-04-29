using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using echarging.Data;
using echarging.Models;

namespace echarging.Pages.kwhdata
{
    public class CreateModel : PageModel
    {
        private readonly echarging.Data.echargingContext _context;

        public CreateModel(echarging.Data.echargingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kwh Kwh { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Kwh.Add(Kwh);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

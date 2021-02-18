using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using echarging.Data;
using echarging.Models;

namespace echarging.Pages.kwhdata
{
    public class DeleteModel : PageModel
    {
        private readonly echarging.Data.echargingContext _context;

        public DeleteModel(echarging.Data.echargingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kwh Kwh { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kwh = await _context.Kwh.FirstOrDefaultAsync(m => m.Date == id);

            if (Kwh == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kwh = await _context.Kwh.FindAsync(id);

            if (Kwh != null)
            {
                _context.Kwh.Remove(Kwh);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

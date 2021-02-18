using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using echarging.Data;
using echarging.Models;

namespace echarging.Pages.kwhdata
{
    public class EditModel : PageModel
    {
        private readonly echarging.Data.echargingContext _context;

        public EditModel(echarging.Data.echargingContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kwh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KwhExists(Kwh.Date))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KwhExists(string id)
        {
            return _context.Kwh.Any(e => e.Date == id);
        }
    }
}

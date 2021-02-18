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
    public class DetailsModel : PageModel
    {
        private readonly echarging.Data.echargingContext _context;

        public DetailsModel(echarging.Data.echargingContext context)
        {
            _context = context;
        }

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
    }
}

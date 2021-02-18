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
    public class IndexModel : PageModel
    {
        private readonly echarging.Data.echargingContext _context;

        public IndexModel(echarging.Data.echargingContext context)
        {
            _context = context;
        }

        public IList<Kwh> Kwh { get;set; }

        public async Task OnGetAsync()
        {
            Kwh = await _context.Kwh.ToListAsync();
        }
    }
}

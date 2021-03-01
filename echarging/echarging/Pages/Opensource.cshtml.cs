using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace echarging.Pages
{
    public class OpensourceModel : PageModel
    {
        private readonly ILogger<OpensourceModel> _logger;

        public OpensourceModel(ILogger<OpensourceModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzz.Models;
using FizzBuzz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public FizzBuzz_Data FizzBuzz_Data { get; set; }
        private readonly FizzBuzzContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                FizzBuzz_Data.Calculate();

                _context.Add(FizzBuzz_Data);
                _context.SaveChanges();

                HttpContext.Session.SetString("SessionFizzBuzz", JsonConvert.SerializeObject( FizzBuzz_Data ));

                return RedirectToPage("./Recently_Searched");
            }
            return Page();
        }

        public void OnGet()
        {

        }
    }
}

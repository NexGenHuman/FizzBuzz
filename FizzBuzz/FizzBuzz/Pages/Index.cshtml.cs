using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzz.Models;

namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public FizzBuzz_Data FizzBuzz_Data { get; set; }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                FizzBuzz_Data.Calculate();
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

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
    public class Recently_SearchedModel : PageModel
    {
        List<FizzBuzz_Data> FBlist = new List<FizzBuzz_Data>();
        public void OnGet()
        {
            var FizzBuzzAddress = HttpContext.Session.GetString("FizzBuzzAddress");
            if (FizzBuzzAddress != null)
                FBlist.Add(JsonConvert.DeserializeObject<FizzBuzz_Data>(FizzBuzzAddress));
        }
    }
}
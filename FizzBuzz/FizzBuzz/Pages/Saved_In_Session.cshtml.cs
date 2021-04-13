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
    public class Saved_In_SessionModel : PageModel
    {
        public List<FizzBuzz_Data> FBlist = new List<FizzBuzz_Data>();

        public void OnGet()
        {
            var SessionList = HttpContext.Session.GetString("SessionList");
            if (SessionList != null)
                FBlist = JsonConvert.DeserializeObject<List<FizzBuzz_Data>>(SessionList);

            var SessionFizzBuzz = HttpContext.Session.GetString("SessionFizzBuzz");
            if (SessionFizzBuzz != null)
            {
                FBlist.Add(JsonConvert.DeserializeObject<FizzBuzz_Data>(SessionFizzBuzz));
                HttpContext.Session.Remove("SessionFizzBuzz");
            }

            HttpContext.Session.SetString("SessionList", JsonConvert.SerializeObject(FBlist));
        }
    }
}
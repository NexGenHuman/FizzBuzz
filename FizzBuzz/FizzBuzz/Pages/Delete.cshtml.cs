using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using FizzBuzz.Data;

namespace FizzBuzz.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }

        private readonly FizzBuzzContext _context;
        public DeleteModel(FizzBuzzContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            int _Id = Convert.ToInt32(id);
            clickAction(_Id);
            Response.Redirect("/Recently_Searched");
        }

        public void clickAction(int _id)
        {
            var FizzBuzzQuery = from FB in _context.fizzBuzz_Data where FB.id == _id select FB;

            _context.Remove(FizzBuzzQuery.First());
            _context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzz.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Data.SqlClient;
using FizzBuzz.Data;
using Microsoft.AspNetCore.Authorization;

namespace FizzBuzz.Pages
{
    [Authorize]
    public class Recently_SearchedModel : PageModel
    {
        private readonly ILogger<Recently_SearchedModel> _logger;
        private readonly FizzBuzzContext _context;
        public Recently_SearchedModel(ILogger<Recently_SearchedModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<FizzBuzz_Data> FBdata { get; set; }

        public void OnGet()
        {
            var FizBuzzQuery = from FB in _context.fizzBuzz_Data orderby FB.date descending select FB;

            FBdata = FizBuzzQuery.Take(10).ToList();
         
            /*
            SqlConnection con = new SqlConnection(FizzBuzzDBcs);
            string sql = "" +
                "SELECT TOP 10 * " +
                "FROM FizzBuzzRecent " +
                "ORDER BY date DESC";
            SqlCommand cmd = new SqlCommand(sql, con);
            */
        }
    }
}
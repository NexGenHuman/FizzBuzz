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
using System.Data.SqlClient;
using System.Data;

namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        public IConfiguration _configuration { get; }
        public IndexModel(IConfiguration configuration) { _configuration = configuration; }

        [BindProperty]
        public FizzBuzz_Data FizzBuzz_Data { get; set; }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                FizzBuzz_Data.Calculate();
                //Database
                string FizzBuzzDBcs = _configuration.GetConnectionString("FizzBuzzDB");

                SqlConnection con = new SqlConnection(FizzBuzzDBcs);
                SqlCommand cmd = new SqlCommand("sp_FizzBuzzAdd", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter input_SqlParam = new SqlParameter("@input", SqlDbType.Int);
                input_SqlParam.Value = FizzBuzz_Data.input;
                cmd.Parameters.Add(input_SqlParam);

                SqlParameter output_SqlParam = new SqlParameter("@output", SqlDbType.VarChar, 10);
                output_SqlParam.Value = FizzBuzz_Data.output;
                cmd.Parameters.Add(output_SqlParam);

                SqlParameter date_SqlParam = new SqlParameter("@date", SqlDbType.DateTime);
                date_SqlParam.Value = FizzBuzz_Data.date;
                cmd.Parameters.Add(date_SqlParam);

                SqlParameter Id_SqlParam = new SqlParameter("@Id", SqlDbType.Int);
                Id_SqlParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Id_SqlParam);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                //Session
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

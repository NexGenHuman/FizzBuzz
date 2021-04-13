using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FizzBuzz.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }

        public IConfiguration _configuration { get; }
        public DeleteModel(IConfiguration configuration) { _configuration = configuration; }
        public void OnGet()
        {
            int _Id = Convert.ToInt32(id);
            clickAction(_Id);
            Response.Redirect("/Recently_Searched");
        }

        public void clickAction(int _id)
        {
            string FizzBuzzDBcs = _configuration.GetConnectionString("FizzBuzzDB");

            SqlConnection con = new SqlConnection(FizzBuzzDBcs);
            string sql = "" +
                "DELETE FROM FizzBuzzRecent " +
                "WHERE Id=" + _id.ToString();

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
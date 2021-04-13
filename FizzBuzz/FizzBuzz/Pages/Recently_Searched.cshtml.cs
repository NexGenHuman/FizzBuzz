﻿using System;
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

namespace FizzBuzz.Pages
{
    public class Recently_SearchedModel : PageModel
    {
        public string lblInfoText;

        private readonly ILogger<Recently_SearchedModel> _logger;
        public IConfiguration _configuration { get; }
        public Recently_SearchedModel(IConfiguration configuration, ILogger<Recently_SearchedModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        //public List<FizzBuzz_Data> FBlist = new List<FizzBuzz_Data>();

        public void OnGet()
        {
            string FizzBuzzDBcs = ConfigurationExtensions.GetConnectionString(this._configuration, "FizzBuzzDB");

            SqlConnection con = new SqlConnection(FizzBuzzDBcs);
            string sql = "SELECT * FROM FizzBuzzRecent";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            StringBuilder htmlStr = new StringBuilder("");
            while (reader.Read())
            {
                htmlStr.Append("<div class=\"text-center row\">");
                htmlStr.Append("<div class=\"col-md-4\">");
                htmlStr.Append("<p>");
                htmlStr.Append(reader["output"].ToString() + " ");
                htmlStr.Append("</p>");
                htmlStr.Append("</div>");
                htmlStr.Append("<div class=\"col-md-4\">");
                htmlStr.Append("<p>");
                htmlStr.Append(reader["input"].ToString() + " ");
                htmlStr.Append("</p>");
                htmlStr.Append("</div>");
                htmlStr.Append("<div class=\"col-md-4\">");
                htmlStr.Append("<p>");
                htmlStr.Append(reader["date"].ToString() + " ");
                htmlStr.Append("</p>");
                htmlStr.Append("</div>");
                htmlStr.Append("</div>");
            }

            reader.Close();
            con.Close();
            lblInfoText = htmlStr.ToString();

            /*
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
            */
        }
    }
}
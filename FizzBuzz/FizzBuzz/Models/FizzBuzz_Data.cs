using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Models
{
    public class FizzBuzz_Data
    {
        public int input { get; set; }
        public string output { get; set; }
        public DateTime date { get; set; }
        public FizzBuzz_Data()
        {
            output = "";
            date = DateTime.Now;
            if (input % 3 == 0)
                output += "Fizz";
            if (input % 5 == 0)
                output += "Buzz";
            if (output == "")
                output = "Liczba " + input + "nie spełnia kryteriów Fizz/Buzz";
        }
    }
}

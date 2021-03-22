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
        public FizzBuzz_Data(int inpt)
        {
            output = "";
            date = DateTime.Now;
            input = inpt;
            if (inpt % 3 == 0)
                output += "Fizz";
            if (inpt % 5 == 0)
                output += "Buzz";
            if (output == "")
                output = "Liczba " + input + "nie spełnia kryteriów Fizz/Buzz";
        }
    }
}

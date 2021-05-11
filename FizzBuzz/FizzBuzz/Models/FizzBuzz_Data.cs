using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzz.Models
{
    public class FizzBuzz_Data
    {
        [Key]
        public int id { get; set; }
        [Required, Range(1, 1000, ErrorMessage = "Wprowadź liczbę pomiędzy 1 a 1000"), Display(Name = "Pole wejścia")]
        public int input { get; set; }
        public string output { get; set; }
        public DateTime date { get; set; }
        public void Calculate()
        {
            output = "";
            date = DateTime.Now;
            if (input % 3 == 0)
                output += "Fizz";
            if (input % 5 == 0)
                output += "Buzz";
            if (output == "")
                output = "Liczba " + input + " nie spełnia kryteriów Fizz/Buzz";
        }
    }
}

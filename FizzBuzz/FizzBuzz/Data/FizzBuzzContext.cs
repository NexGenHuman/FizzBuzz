using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Models;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzz.Data
{
    public class FizzBuzzContext : DbContext
    {
        public DbSet<FizzBuzz_Data> fizzBuzz_Data { get; set; }

        public FizzBuzzContext(DbContextOptions options) : base(options)
        { }
    }
}

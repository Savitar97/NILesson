using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebApi_Common.Models
{
    public class Person
    {
        public long Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

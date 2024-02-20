using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradeTEST.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClientStatus Status { get; set; }
        public Manager Manager { get; set; }
        public Product Products { get; set; }
    }
}

using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CGICodeTest.Models
{
    public class BusinessCard
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public byte[] Image { get; set; }
    }
}

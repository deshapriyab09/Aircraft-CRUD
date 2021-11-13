using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcraftAPI.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Make { get; set; }
        [MaxLength(128)]
        public string Model { get; set; }
        public string Registration { get; set; }
        [MaxLength(128)]
        public string Location { get; set; }
        public string PhotoPath { get; set; }
        public DateTime DateTime { get; set; }
    }
}

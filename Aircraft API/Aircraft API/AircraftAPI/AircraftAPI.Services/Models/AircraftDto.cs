using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftAPI.Services.Models
{
    public class AircraftDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Location { get; set; }
        public string PhotoPath { get; set; }
        public DateTime DateTime { get; set; }

    }
}

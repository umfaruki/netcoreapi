using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi_Umer.Models
{
    public class BookingPartModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public string Status { get; set; }       
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

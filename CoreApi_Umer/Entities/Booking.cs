using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi_Umer.Entities
{
    public class Booking
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual ICollection<BookingPart> BookingParts { get; set; }
    }
}

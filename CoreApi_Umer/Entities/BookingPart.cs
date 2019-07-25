using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi_Umer.Entities
{
    public class BookingPart
    {
        public virtual string Id { get; set; }
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual int Status { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual DateTime CreationDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }

        public BookingPart()
        {
            CreationTime = DateTime.UtcNow;
            Status = (int)BookingPartStatus.Confirmed;
        }

    }

    public enum BookingPartStatus : byte
    {
        /// <summary>
        /// Confirmed Status.
        /// </summary>
        Confirmed = 0,

        /// <summary>
        /// Under Review.
        /// </summary>
        UnderReview = 1,

        /// <summary>
        /// Ticketed.
        /// </summary>
        Ticketed = 2,

        /// <summary>
        /// Cancled.
        /// </summary>
        Cancled = 3
    }
}

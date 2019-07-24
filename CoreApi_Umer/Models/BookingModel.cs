using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi_Umer.Models
{
    public class BookingModel
    {
        public Guid BookingId { get; set; }
        public string Description { get; set; }
        public DateTime BookDate { get; set; }

        public List<BookingModel> DefaultBookings()
        {
            return new List<BookingModel>
            {
                new BookingModel
                {
                    BookingId = Guid.NewGuid(),
                    Description = "Test desc 1",
                    BookDate = DateTime.Now.AddDays(-205)
                },
                new BookingModel
                {
                    BookingId = Guid.NewGuid(),
                    Description = "Test desc 2",
                    BookDate = DateTime.Now.AddDays(-25)
                },
                new BookingModel
                {
                    BookingId = Guid.NewGuid(),
                    Description = "Test desc 3",
                    BookDate = DateTime.Now.AddDays(-5)
                },
                new BookingModel
                {
                    BookingId = Guid.NewGuid(),
                    Description = "Test desc 4",
                    BookDate = DateTime.Now.AddDays(-250)
                },
                new BookingModel
                {
                    BookingId = Guid.NewGuid(),
                    Description = "Test desc 5",
                    BookDate = DateTime.Now.AddDays(-105)
                },
                new BookingModel
                {
                    BookingId = Guid.NewGuid(),
                    Description = "Test desc 6",
                    BookDate = DateTime.Now.AddDays(-105)
                },
                new BookingModel
                {
                    BookingId = Guid.NewGuid(),
                    Description = "Test desc 7",
                    BookDate = DateTime.Now.AddDays(-305)
                }
            };
        }
    }
}

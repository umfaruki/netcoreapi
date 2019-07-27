using CoreApi_Umer.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi_Umer.Maps
{
    public class BookingPartMap : ClassMap<BookingPart>
    {
        public BookingPartMap()
        {
            Id(x => x.Id);

            Map(x => x.CreationTime);
            Map(x => x.Status);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.UpdatedDate);
            Map(x => x.CreationDate);

            //Use References to create relationship with Parent;
            References(x => x.Booking).Column("BookingId").Cascade.All();
           
        }
    }
}

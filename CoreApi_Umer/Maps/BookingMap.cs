using CoreApi_Umer.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi_Umer.Maps
{
    public class BookingMap : ClassMap<Booking>
    {
        public BookingMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.CreationDate);
            Map(x => x.UpdatedDate);

            // One to May relation
            HasMany(x => x.BookingParts)
                                   .AsSet()
                                   .Inverse()
                                   .Cascade.All();
        }
    }
}
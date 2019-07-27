using AutoMapper;
using CoreApi_Umer.Entities;
using CoreApi_Umer.Helpers;
using CoreApi_Umer.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CoreApi_Umer.Services
{
    public class BookingService
    {
        public static List<BookingModel> GetBookings(Booking book = null)
        {
            using (var session = SessionFactoryBuilder.OpenSession())
            {
                var bookings = session.Query<Booking>().ToList();

                var bookingsModel = new List<BookingModel>();
                bookings.ForEach(booking => 
                {

                    var tempModel = new BookingModel
                    {
                        Id = booking.Id,
                        Name = booking.Name,
                        CreationDate = booking.CreationDate,
                        UpdatedDate = booking.UpdatedDate,                      
                    };
                    tempModel.BookingParts = new List<BookingPartModel>();
                    booking.BookingParts.ToList().ForEach(bpt => 
                    {
                        tempModel.BookingParts.Add(new BookingPartModel
                        {
                            Id = bpt.Id,
                            Title = bpt.Title,
                            Status = bpt.Status.ToString(),
                            CreationDate = bpt.CreationDate,
                            Description = bpt.Description,
                            UpdatedDate = bpt.UpdatedDate,
                            CreationTime = bpt.CreationTime
                        });
                    });

                    bookingsModel.Add(tempModel);




                });
               
                return bookingsModel;
            }

            //using (var session = SessionFactoryBuilder.OpenSession())
            //{
            //    using (ITransaction transaction = session.BeginTransaction())
            //    {
            //        session.Save(new BookingPart { });
            //        transaction.Commit();
            //    }
            //}

            //var sessionFactory = SessionFactoryBuilder.BuildSessionFactory(true, true);
            //using (var session = sessionFactory.OpenSession())
            //{
            //    // populate the database  
            //    //using (var transaction = session.BeginTransaction())
            //    //{
            //    //    // create a couple of Persons  
            //    //    var person1 = new Person
            //    //    {
            //    //        Name = "Rayen Trabelsi"
            //    //    };
            //    //    var person2 = new Person
            //    //    {
            //    //        Name = "Mohamed Trabelsi"
            //    //    };
            //    //    var person3 = new Person
            //    //    {
            //    //        Name = "Hamida Rebai"
            //    //    };
            //    //    //create tasks  
            //    //    var task1 = new Task
            //    //    {
            //    //        Title = "Task 1",
            //    //        State = TaskState.Open,
            //    //        AssignedTo = person1
            //    //    };
            //    //    var task2 = new Task
            //    //    {
            //    //        Title = "Task 2",
            //    //        State = TaskState.Closed,
            //    //        AssignedTo = person2
            //    //    };
            //    //    var task3 = new Task
            //    //    {
            //    //        Title = "Task 3",
            //    //        State = TaskState.Closed,
            //    //        AssignedTo = person3
            //    //    };
            //    //    // save both stores, this saves everything else via cascading  
            //    //    session.SaveOrUpdate(task1);
            //    //    session.SaveOrUpdate(task2);
            //    //    session.SaveOrUpdate(task3);
            //    //    transaction.Commit();
            //    //}
            //    using (var session2 = sessionFactory.OpenSession())
            //    {
            //        //retreive all tasks with person assigned to  
            //        using (session2.BeginTransaction())
            //        {
            //            var bookingParts = session.CreateCriteria(typeof(Booking)).List<Booking>();
            //            return bookingParts.ToList();

            //        }
            //    }

            //}

            //return new List<Booking>();
        }

        public static List<BookingModel> SaveBooking(BookingModel bookingData = null)
        {

            var dbBooking = new Booking();

            dbBooking.Id = bookingData.Id;
            dbBooking.Name = bookingData.Name;
            dbBooking.CreationDate = DateTime.Now;
            dbBooking.UpdatedDate = DateTime.Now;
            //dbBooking.BookingParts = new List<BookingPart>();

            bookingData.BookingParts.ForEach(bpt =>
            {
                dbBooking.Add(new BookingPart
                {
                    Id = bpt.Id,
                    CreationDate = DateTime.Now,
                    CreationTime = DateTime.Now,
                    Status = 2,
                    Description = bpt.Description,
                    Title = bpt.Title,
                    UpdatedDate = DateTime.Now,
                });
            });

            using (var session = SessionFactoryBuilder.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(dbBooking);
                    transaction.Commit();
                }
            }

            return GetBookings();


        }
    }
    
}


using CoreApi_Umer.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi_Umer.Helpers
{
    public class SessionFactoryBuilder
    {
        //var listOfEntityMap = typeof(M).Assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(M))).ToList();  
        //var sessionFactory = SessionFactoryBuilder.BuildSessionFactory(dbmsTypeAsString, connectionStringName, listOfEntityMap, withLog, create, update);  
        public static ISessionFactory BuildSessionFactory(bool create = false, bool update = false)
        {

            //var dbConnection = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            var dbConnection = ConfigurationManager.ConnectionStrings[0];
            var connStr = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=C:\USERS\UMER\SOURCE\REPOS\NETCOREAPI\COREAPI_UMER\DATABASE\BOOKINGDB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            return FluentNHibernate.Cfg.Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                //.Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))  
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernate.Cfg.Mappings>())
                .CurrentSessionContext("call").ExposeConfiguration(cfg => BuildSchema(cfg, create, update)).BuildSessionFactory();
        }

        /// <summary>  
        /// Build the schema of the database.  
        /// </summary>  
        /// <param name="config">Configuration.</param>  
        private static void BuildSchema(NHibernate.Cfg.Configuration config, bool create = false, bool update = false)
        {
            if (create)
            {
                new SchemaExport(config).Create(false, true);
            }
            else
            {
                new SchemaUpdate(config).Execute(false, update);
            }
        }

        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Umer\source\repos\netcoreapi\CoreApi_Umer\Database\bookingDb.mdf;Integrated Security=True;Connect Timeout=30")
                              .ShowSql()
                )
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Booking>())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BookingPart>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}

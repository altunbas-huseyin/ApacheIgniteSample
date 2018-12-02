using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Client;
using Apache.Ignite.Core.Client.Cache;
using System;

namespace ApacheIgniteClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var cfg = new IgniteClientConfiguration
            {
                Host = "127.0.0.1",
                //UserName = "ignite",
                //Password = "kg1mmcoXZU"
            };

            using (IIgniteClient ignite = Ignition.StartClient(cfg))
            {

                ICacheClient<int, string> cache = ignite.GetOrCreateCache<int, string>("cache1");
                cache.Put(1, "Hello, World!");
                string value = cache.Get(1);


                //var cache = ignite.GetOrCreateCache<long, City>("SQL_PUBLIC_CITY");

                //cache.Query(new SqlFieldsQuery("INSERT INTO City1(id, name) values (1, 'Forest Hill') "));
            }


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }

    public class City
    {
        [QuerySqlField(IsIndexed = true)]
        public int id { get; set; }
        [QuerySqlField]
        public string name { get; set; }
    }

}

using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Configuration;
using System;

namespace ApacheIgniteServer
{
    class Program
    {
        static void Main(string[] args)
        {

            var cfg = new IgniteConfiguration
            {
                DataStorageConfiguration = new DataStorageConfiguration
                {
                    DefaultDataRegionConfiguration = new DataRegionConfiguration
                    {
                        Name = "defaultRegion",
                        PersistenceEnabled = true
                    },
                    DataRegionConfigurations = new[]
                     {
                            new DataRegionConfiguration
                            {
                                // Persistence is off by default.
                                Name = "inMemoryRegion"
                            }
                        }
                },
                CacheConfiguration = new[]
                 {
                        new CacheConfiguration
                        {
                            // Default data region has persistence enabled.
                            Name = "persistentCache"
                        },
                        new CacheConfiguration
                        {
                            Name = "inMemoryOnlyCache",
                            DataRegionName = "inMemoryRegion"
                        }
                    }
            };
            cfg.WorkDirectory = @"C:\\workDirectory";
            var t = Ignition.Start(cfg);
            t.SetActive(true);
            var tt = t.GetCluster().Ignite.GetCluster().GetNode().ConsistentId.ToString();
            Console.WriteLine("Hello World! " + tt);

            Console.ReadLine();
        }
    }
}

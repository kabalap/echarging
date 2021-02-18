using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using echarging.Data;
using echarging.Models;


namespace unibook.Data
{
    public class DbInitializer
    {
        public static void Initialize(echargingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any price of kwh.
            if (context.Kwh.Any())
            {
                return;   // DB has been seeded
            }

            var kwh = new Kwh[]
           {
                new Kwh{Date="DateTest",T00=00,T01=01,T02=02,T03=03,T04=04,
                    T05=05,T06=06,T07=07,T08=08,T09=09,T10=10,T11=11,
                    T12=12,T13=13,T14=14, T15=15,T16=16,T17=17,T18=18,T19=19,T20=21,
                    T21=21,T22=22,T23=23,},
           };
            foreach (Kwh k in kwh)
            {
                context.Kwh.Add(k);
            }
            context.SaveChanges();
        }
    }
}

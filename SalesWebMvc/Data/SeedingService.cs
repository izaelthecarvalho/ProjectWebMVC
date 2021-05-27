using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecords.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Book");
            Department d3 = new Department(3, "ball");

            Seller s1 = new Seller(1, "Mano Brown", "izal@e.com", new DateTime(1998, 4, 21), 1000.00, d1);
            Seller s2 = new Seller(2, "Mana Brown", "Wzal@e.com", new DateTime(1997, 4, 21), 1000.00, d2);

            SalesRecord R1 = new SalesRecord(1, new DateTime(2018, 09, 25), 1100, SalesStatus.Billed, s1);


            _context.Department.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1, s2);
            _context.SalesRecords.AddRange(R1);

            _context.SaveChanges();
        }

    }
}

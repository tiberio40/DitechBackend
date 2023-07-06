using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DitechPruebaContext _context;

        public IRepository<City> _cities;
        public IRepository<Seller> _sellers;

        public UnitOfWork(DitechPruebaContext context) { 
            _context = context;
        }


        public IRepository<City> Cities {
            get {
                return _cities == null ? _cities = new Repository<City>(_context) : _cities;
            }
        }

        public IRepository<Seller> Sellers
        {
            get
            {
                return _sellers == null ? _sellers = new Repository<Seller>(_context) : _sellers;
            }
        }


        public void Save() { 
            _context.SaveChanges();
        }
    }
}

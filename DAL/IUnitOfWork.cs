using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        public IRepository<City> Cities { get; }

        public IRepository<Seller> Sellers { get; }

        public void Save();
    }
}

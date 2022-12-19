using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDBContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDBContext = appDbContext;
            Category = new CategoryRepository(_appDBContext);
        }

        public ICategoryRepository Category { get; private set; }

        public void Save()
        {
            _appDBContext.SaveChanges();
        }
    }
}

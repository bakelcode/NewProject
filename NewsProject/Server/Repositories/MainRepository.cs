using Microsoft.EntityFrameworkCore;
using NewsProject.Server.Models;
using NewsProject.Server.Repositories.Intefaces;

namespace NewsProject.Server.Repositories
{
    public class MainRepository<T> : MainInteface<T> where T : class
    {
        private readonly AppDbContext _db;

        public MainRepository(AppDbContext db)
        {
            _db = db;
        }

        public T AddRow(T model)
        {
            _db.Set<T>().Add(model);
            _db.SaveChanges();
            return model;
        }

        public void DeleteRow(int id)
        {
            var model = GetRowById(id);
            _db.Set<T>().Remove(model);
            _db.SaveChanges();
        }

        public IEnumerable<T> GetAllDate(string[] includes = null)
        {
            IQueryable<T> myQuery = _db.Set<T>();
            if (includes != null)
            {
                foreach( var include in includes)
                myQuery = myQuery.Include(include);
           
            }
            return myQuery.ToList();
        }

        public T GetRowById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T UpdateRow(T model)
        {
            DbSet<T> ts = _db.Set<T>();
            ts.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
            return model;
        }
    }
}

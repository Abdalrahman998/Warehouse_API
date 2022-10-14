using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Generic
{
    public class Generic<T>:IGeneric<T> where T : class
    {
        SystemContext context;

        public Generic(SystemContext _context)
        {
            context = _context;
        }
        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }
        public void Update(T obj)
        {
            context.Set<T>().Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(int Id)
        {
            T obj = context.Set<T>().Find(Id);
            context.Set<T>().Remove(obj);
            context.SaveChanges();
        }
        public T Load(int Id)
        {
            T obj = context.Set<T>().Find(Id);
            return obj;
        }
        public List<T> LoadAll()
        {
            List<T> liobj = context.Set<T>().ToList();
            return liobj;
        }
    }
}

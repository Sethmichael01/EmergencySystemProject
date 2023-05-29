using Microsoft.EntityFrameworkCore;

using MOBILE_BASED.DAL.Context;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.Concrete
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly EmergencySystemDbContext Db;
        private readonly DbSet<T> _dbSet;
        private readonly IUserContext _userContext;

        public Repo(EmergencySystemDbContext db, IUserContext userContext)
        {
            Db = db;
            _dbSet = Db.Set<T>();
            _userContext = userContext;
        }
        public async Task<List<T>> GetAll(string includeProperties = "", bool isActive = false, int take = 0)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllById(string includeProperties = "", Expression<Func<T, bool>> filter = null, bool isActive = false)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDeafult(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Save(T t, string userName)
        {
            await Db.AddAsync(t);
        }

        public void Update(T t, string username)
        {
            Db.Entry(t).State = EntityState.Modified;
        }

        public async Task<bool> CheckAny(int id)
        {
            var t = await _dbSet.FindAsync(id);
            return t != null;
        }

        public async Task Delete(int id)
        {
            var t = await _dbSet.FindAsync(id);
            if (Db.Entry(t).State == EntityState.Detached)
            {
                _dbSet.Attach(t);
            }
            _dbSet.Remove(t);
        }

        public async Task Delete(string id)
        {
            var t = await _dbSet.FindAsync(id);
            if (Db.Entry(t).State == EntityState.Detached)
            {
                _dbSet.Attach(t);
            }
            _dbSet.Remove(t);
        }

        public void Delete(T t)
        {
            if (t != null)
            {
                if (Db.Entry(t).State == EntityState.Detached)
                {
                    _dbSet.Attach(t);
                }
                _dbSet.Remove(t);
            }
        }

        public void DetachEntry(T t)
        {
            Db.Entry(t).State = EntityState.Detached;
        }
        public async Task<ResponseVm> SaveContext()
        {
            try
            {
                await Db.SaveChangesAsync();
                return new ResponseVm { Status = true, Message = "Commit Successfully" };
            }
            catch (Exception e)
            {
                return new ResponseVm { Status = false, Message = e.Message };
            }
        }

        public string UserId
        {
            get
            {
                return _userContext?.GetUserId() ?? "";
            }
            set { }
        }
    }
}

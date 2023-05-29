using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MOBILE_BASED.Infrastructure.Abstractions
{
    public interface IRepo<T> where T : class
    {
        Task<List<T>> GetAll(string includeProperties = "", bool isActive = false, int take = 0);
        Task<List<T>> GetAllById(string includeProperties = "", Expression<Func<T, bool>> filter = null, bool isActive = false);
        Task<T> GetById(int id);
        Task<T> GetById(string id);
        Task<T> GetFirstOrDeafult(Expression<Func<T, bool>> filter, string includeProperties = "");
        Task<bool> CheckAny(int id);
        Task Save(T t, string username);
        void Update(T t, string username);
        void DetachEntry(T t);
        Task Delete(int t);
        Task Delete(string t);
        void Delete(T t);
        Task<ResponseVm> SaveContext();
        public string UserId { get; set; }
    }
}

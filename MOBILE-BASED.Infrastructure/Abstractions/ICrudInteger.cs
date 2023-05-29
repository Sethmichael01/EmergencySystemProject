using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MOBILE_BASED.Infrastructure.Abstractions
{
    public interface ICrudInteger<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<ResponseVm> AddOrUpdate(T t);
        Task<ResponseVm> Delete(int id);
    }
}

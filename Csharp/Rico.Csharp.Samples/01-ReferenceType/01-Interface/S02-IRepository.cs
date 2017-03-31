using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Rico.Csharp.Samples.InterfaceSample
{
    interface IRepository
    {
        Task AddAsync();
    }

    interface IUser: IRepository
    {
        [Description("添加用户")]
        bool AddUser();
    }

    public class UserRepostory : IUser
    {
        public Task AddAsync()
        {
            throw new NotImplementedException();
        }

        public bool AddUser()
        {
            throw new NotImplementedException();
        }
    }
    interface IRepository<T> where T:class 
    {
        Task AddAsync(T item);
    }


}

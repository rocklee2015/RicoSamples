using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Consoles.EF
{
    class Program
    {
        static void Main(string[] args)
        {

            //EF_Extended_Delete();
            System.Diagnostics.Debug.WriteLine("ss");
        }
        public void 表拆分_实体拆分()
        {
            using (var context = new BloggingContext())
            {
                context.Blogs.Add(new Blog { Remark = "", Title = "EntityFramework 实体拆分和表拆分", Url = "http://www.cnblogs.com/xishuai/p/ef-entity-table-splitting.html" });
                context.SaveChanges();
            }
            using (var context = new BloggingContext())
            {
                var model = context.Blogs.FirstOrDefault(p => p.Id == 1);
            }
        }
        static void EF_EntityStateAndEntry()
        {
            using (var context = new BloggingContext())
            {
                var list = new List<User>();
                list.Add(new User() { UserName = "CC", Address = 1, Age = 2 });
                list.Add(new User() { UserName = "DD", Address = 3, Age = 4 });
                foreach (var model in list)
                {
                    context.Entry(model).State = EntityState.Added;
                }
                context.SaveChanges();
            }
        }
        static void EF_Extended()
        {
            
            using (var context = new BloggingContext())
            {
                //EntityFramework Entended --Update
                //已过时,改成对IQuerable扩展了
                //context.Users.Update( u => u.Id==1002, u2 => new User { UserName = "SS" });
                context.Users.Where(p => p.Id == 1002).Update(p2 => new User() { Age = p2.Age * 10, Address = p2.Address * 10 });
                //context.SaveChanges();--无需SaveChanges
            }
        }
        static void EF_Extended_Delete()
        {
            using (var context = new BloggingContext())
            {
                context.Users.Where(p => p.Id == 1002).Delete();
                //context.SaveChanges();
            }
        }
    }
}

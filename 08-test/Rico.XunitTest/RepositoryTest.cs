using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rico.XunitTest.CodeSource;
using Xunit;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Rico.XunitTest
{
    public class EfRepositoryTests : IDisposable
    {
        private const string TestDatabaseConnectionName = "DefaultConnectionTest";

        private readonly DbContext _context;

        private readonly IRepository<User> _repository;//用具体的泛型类型进行测试，这个不影响对EFRepository测试的效果



        public EfRepositoryTests()

        {

            _context = new ObjectContext(TestDatabaseConnectionName);

            _repository = new EfRepository<User>(_context);

        }



        [Fact]
        public void Test_insert_getbyid_table_tablenotracking_delete_success()
        {
            var user = new User()
            {
                UserName = "zhangsan",
                CreateTime = DateTime.Now,
                LastUpdateTime = DateTime.Now
            };
            _repository.Insert(user);

            var newUserId = user.Id;

            Assert.True(newUserId > 0);



            //声明新的Context，不然查询直接由DbContext返回而不经过数据库

            using (var newContext = new MyObjectContext(TestDatabaseConnectionName))

            {

                var repository = new EfRepository<User>(newContext);

                var userInDb = repository.GetById(newUserId);

                user.UserName.ShouldEqual(userInDb.UserName);

            }



            using (var newContext = new MyObjectContext(TestDatabaseConnectionName))

            {

                var repository = new EfRepository<User>(newContext);

                var userInDb = repository.Table.Single(r => r.Id == newUserId);

                user.UserName.ShouldEqual(userInDb.UserName);

            }



            using (var newContext = new MyObjectContext(TestDatabaseConnectionName))

            {

                var repository = new EfRepository<User>(newContext);

                var userInDb = repository.TableNoTracking.Single(r => r.Id == newUserId);

                user.UserName.ShouldEqual(userInDb.UserName);

            }



            _context.Entry(user).State.ShouldEqual(EntityState.Unchanged);

            _repository.Delete(user);



            using (var newContext = new MyObjectContext(TestDatabaseConnectionName))

            {

                var repository = new EfRepository<User>(newContext);

                var userInDb = repository.GetById(newUserId);

                userInDb.ShouldBeNull();

            }

        }



        [Fact]

        public void Test_insert_update_attach_success()

        {

            var user = new User()

            {

                UserName = "zhangsan",

                CreatedOn = DateTime.Now,

                LastActivityDate = DateTime.Now

            };

            _repository.Insert(user);

            var newUserId = user.Id;

            Assert.True(newUserId > 0);



            //update

            using (var newContext = new MyObjectContext(TestDatabaseConnectionName))

            {

                var repository = new EfRepository<User>(newContext);

                var userInDb = repository.GetById(newUserId);

                userInDb.UserName = "lisi";

                repository.Update(userInDb);

            }



            //assert

            using (var newContext = new MyObjectContext(TestDatabaseConnectionName))

            {

                var repository = new EfRepository<User>(newContext);

                var userInDb = repository.GetById(newUserId);

                userInDb.UserName.ShouldEqual("lisi");

            }



            //update by attach&modifystate

            using (var newContext = new MyObjectContext(TestDatabaseConnectionName))

            {

                var repository = new EfRepository<User>(newContext);

                var userForUpdate = new User()

                {

                    Id = newUserId,

                    UserName = "wangwu",

                    CreatedOn = DateTime.Now,

                    LastActivityDate = DateTime.Now

                };

                repository.Attach(userForUpdate);

                var entry = newContext.Entry(userForUpdate);

                entry.State.ShouldEqual(EntityState.Unchanged);//assert

                entry.State = EntityState.Modified;

                repository.Update(userForUpdate);

            }



            //assert

            using (var newContext = new MyObjectContext(TestDatabaseConnectionName))

            {

                var repository = new EfRepository<User>(newContext);

                var userInDb = repository.GetById(newUserId);

                userInDb.UserName.ShouldEqual("wangwu");

            }

            _repository.Delete(user);

        }



        public void Dispose()

        {

            _context.Dispose();

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

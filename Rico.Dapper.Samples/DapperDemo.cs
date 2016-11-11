using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Dapper.Samples
{
    public class DapperDemo
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        public  void InsertUser()
        {
            string sqlCommandText = @"INSERT INTO CICUser(Username,PasswordHash,Email,PhoneNumber)VALUES(
    @UserName,
    @Password,
    @Email,
    @PhoneNumber
)";
            using (IDbConnection conn = GetSqlConnection())
            {
                User user = new User();
                user.UserId = 10;
                user.UserName = "rico";
                user.PasswordHash = "654321";
                user.Email = "Dapper@rico.com";
                user.PhoneNumber = "13795666243";
                int result = conn.Execute(sqlCommandText, user);
                if (result > 0)
                {
                    Console.WriteLine("Data have already inserted into DB!");
                }
                else
                {
                    Console.WriteLine("Insert Failed!");
                }

                Console.ReadLine();
            }
        }
        public User Get()
        {
            using (IDbConnection conn = GetSqlConnection())
            {
                var user =conn.QuerySingle<User>("select * from CICUser where UserId=2");
                return user;
            }
        }
        public void InserRole()
        {
            using (IDbConnection conn = GetSqlConnection())
            {
                string sqlCommandText = @"INSERT INTO CICRole(RoleName)VALUES(@RoleName)";
                Role role = new Role();
                role.RoleName = "客服";
                int result = conn.Execute(sqlCommandText, role);
                if (result > 0)
                {
                    Console.WriteLine("Data have already inserted into DB!");
                }
                else
                {
                    Console.WriteLine("Insert Failed!");
                }

                Console.ReadLine();
            }
        }
        public void InserRoleUser()
        {
            using (IDbConnection conn = GetSqlConnection())
            {
                string sqlCommandText = @"INSERT INTO CICUserRole(UserId,RoleId)VALUES(@UserId,@RoleId)";
                var userRole = new UserRole();
                userRole.UserId = 2;
                userRole.RoleId = 1;
                int result = conn.Execute(sqlCommandText, userRole);
                if (result > 0)
                {
                    Console.WriteLine("Data have already inserted into DB!");
                }
                else
                {
                    Console.WriteLine("Insert Failed!");
                }

                Console.ReadLine();
            }
        }
        public  void OneToOne()
        {
            List<Customer> userList = new List<Customer>();
            using (IDbConnection conn = GetSqlConnection())
            {
                string sqlCommandText = @"SELECT c.UserId,c.Username AS UserName,
c.PasswordHash AS [Password],c.Email,c.PhoneNumber,c.IsFirstTimeLogin,c.AccessFailedCount,
c.CreationDate,c.IsActive,r.RoleId,r.RoleName 
    FROM dbo.CICUser c WITH(NOLOCK) 
INNER JOIN CICUserRole cr ON cr.UserId = c.UserId 
INNER JOIN CICRole r ON r.RoleId = cr.RoleId";
                userList = conn.Query<Customer, Role, Customer>(sqlCommandText,
                                                                (user, role) => { user.Role = role; return user; },
                                                                null,
                                                                null,
                                                                true,
                                                                "RoleId",
                                                                null,
                                                                null).ToList();
            }

            if (userList.Count > 0)
            {
                userList.ForEach((item) => Console.WriteLine("UserName:" + item.UserName +
                                                             "----Password:" + item.Password +
                                                             "-----Role:" + item.Role.RoleName +
                                                             "\n"));

                Console.ReadLine();
            }
        }
        private  IDbConnection GetSqlConnection()
        {
            IDbConnection conn = null;
            conn = new SqlConnection(connString);
            conn.Open();
            return conn;
        }
    }
}

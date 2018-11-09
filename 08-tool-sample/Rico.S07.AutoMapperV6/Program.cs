using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S07.AutoMapperV6
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Source, Destination>();
               // cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserOutputDto>();
            });
            var source = new Source();
            source.SomeValue = 10;
            source.Name = "";

            var destination = new Destination();
            destination.Name = "dd";
            destination = Mapper.Map(source,destination);
            
            Console.WriteLine(destination.Name);
            Console.WriteLine(source.Name);

            var user = new User() {  Id=1,Name="ricolee",Age=12,Address="china"};

            var userDto = new UserDto() { Id=1,Name="" };

            user= Mapper.Map<User>(userDto);

            Console.WriteLine(user.Name);
            Console.ReadKey();
        }
    }
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Classes { get; set; }

        public int Age { get; set; }
    }
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class UserOutputDto
    {
        public string Name { get; set; }
    }
    public class Source
    {
        public string Name { get; set; }
        public int SomeValue { get; set; }
        public string AnotherValue { get; set; }
    }

    public class Destination
    {
        public int SomeValue { get; set; }

        public string Name { get; set; }
    }
}

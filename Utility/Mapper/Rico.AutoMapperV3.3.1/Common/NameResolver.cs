using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Rico.AutoMapperV3._3._1.Dto;
using Rico.AutoMapperV3._3._1.Model;

namespace Rico.AutoMapperV3._3._1
{
    public class NameResolver : ValueResolver<Name, NameDto>, IValueResolver
    {
        protected override NameDto ResolveCore(Name source)
        {
            return new NameDto() { FirstName = source.FirstName, LastName = source.LastName, AllName = source.FirstName + source.LastName };
        }
    }
}

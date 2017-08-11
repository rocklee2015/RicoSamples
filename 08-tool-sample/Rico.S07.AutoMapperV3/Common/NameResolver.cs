using AutoMapper;
using Rico.S07.AutoMapperV3.Dto;
using Rico.S07.AutoMapperV3.Model;

namespace Rico.S07.AutoMapperV3.Common
{
    public class NameResolver : ValueResolver<Name, NameDto>, IValueResolver
    {
        protected override NameDto ResolveCore(Name source)
        {
            return new NameDto() { FirstName = source.FirstName, LastName = source.LastName, AllName = source.FirstName + source.LastName };
        }
    }
}

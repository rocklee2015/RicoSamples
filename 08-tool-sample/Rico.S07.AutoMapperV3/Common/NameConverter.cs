using AutoMapper;
using Rico.S07.AutoMapperV3.Dto;
using Rico.S07.AutoMapperV3.Model;

namespace Rico.S07.AutoMapperV3.Common
{
    public class NameConverter : TypeConverter<Name, NameDto>
    {
        protected override NameDto ConvertCore(Name source)
        {
            return new NameDto() { AllName = source.FirstName + source.LastName };
        }
    }
}

using AutoMapper;
using Rico.AutoMapperV3._3._1.Dto;
using Rico.AutoMapperV3._3._1.Model;

namespace Rico.AutoMapperV3._3._1.Common
{
    public class NameConverter : TypeConverter<Name, NameDto>
    {
        protected override NameDto ConvertCore(Name source)
        {
            return new NameDto() { AllName = source.FirstName + source.LastName };
        }
    }
}

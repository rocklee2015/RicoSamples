using AutoMapper;
using Rico.AutoMapperV3._3._1.Dto;

namespace Rico.AutoMapperV3._3._1.Common
{
    public class NameFormatter : ValueFormatter<NameDto>
    {
        protected override string FormatValueCore(NameDto name)
        {
            return name.FirstName + name.LastName;
        }
    }
}

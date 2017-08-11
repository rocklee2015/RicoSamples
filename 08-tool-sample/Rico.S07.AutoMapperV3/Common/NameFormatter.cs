using AutoMapper;
using Rico.S07.AutoMapperV3.Dto;

namespace Rico.S07.AutoMapperV3.Common
{
    public class NameFormatter : ValueFormatter<NameDto>
    {
        protected override string FormatValueCore(NameDto name)
        {
            return name.FirstName + name.LastName;
        }
    }
}

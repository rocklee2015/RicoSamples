using AutoMapper;

namespace Rico.S07.AutoMapperV3.Common
{
    public class StringFormatter : ValueFormatter<string>
    {
        protected override string FormatValueCore(string name)
        {
            return name + "-";
        }
    }
}

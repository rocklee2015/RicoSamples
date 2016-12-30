using AutoMapper;

namespace Rico.AutoMapperV3._3._1.Common
{
    public class StringFormatter : ValueFormatter<string>
    {
        protected override string FormatValueCore(string name)
        {
            return name + "-";
        }
    }
}

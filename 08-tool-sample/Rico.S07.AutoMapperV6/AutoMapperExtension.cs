using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S07.AutoMapperV6
{
    public static class AutoMapperExtension
    {
        public static TTarget MapTo<TTarget>(this object source)
        {
            return Mapper.Map<TTarget>(source);
        }

        public static TTarget MapTo<TTarget>(this object source, TTarget target)
        {
            return Mapper.Map(source,target);
        }
      
    }
}

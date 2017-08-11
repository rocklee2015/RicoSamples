using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitu.Consoles.SocialInsurance
{
    public static class EnumHelper
    {
        /// <summary>
        /// 将枚举字符转换成枚举
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumString"></param>
        /// <returns></returns>
        public static TEnum ConvertStringToEnum<TEnum>(string enumString)
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enumerated type");
            }
            return (TEnum)Enum.Parse(typeof(TEnum), enumString);
        }
    }
}

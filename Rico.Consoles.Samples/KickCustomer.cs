using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Consoles.Samples
{
    public class KickCustomer
    {
        public DateTime CreateTime { get; set; }
        public DateTime KickTime { get; set; }
        public DateTime GetKickTime()
        {
            #region 注释
            //基础停留期：（公海客户5天，自录客户4天）

            //一次追加：
            //1.基础期有A评级，加7天
            //2.基础期有B评级，加5天
            //3.基础期有2次不在同一天联系的，加5天；

            //二次追加：
            //1.基础期有A评级,一次追加期间无论何评级不追加；
            //2.基础期有B评级，一次追加期间有A评级，则再追加7天；
            //3.基础期有2次不在同一天联系的，一次追加期间有B评级则追加5天；一次追加期有A评级则追加7天；

            //三次追加：
            //1.基础期有A评级,二次追加期间无论何评级不追加；
            //2.基础期有2次不在同一天联系的，一次追加期间有B评级且二次追加期间有A评级则再追加7天
            #endregion
            //基础停留期
            KickTime = CreateTime.AddDays(4);
            //一次
            if (IsHaveAOnBase(CreateTime, KickTime))
            {
                //二次，三次都一样
                return KickTime.AddDays(7);
            }
            else if (IsHaveBOnBase(CreateTime, KickTime))
            {
                if (IsHaveAOnFirstAppend(KickTime, KickTime.AddDays(5)))
                {
                    return KickTime.AddDays(5 + 7);
                }
                else
                {
                    return KickTime.AddDays(5);
                }
            }
            else if (IsContactTwiceOnBase(CreateTime, KickTime))
            {
                if (IsHaveAOnFirstAppend(KickTime, KickTime.AddDays(7)))
                {
                    return KickTime.AddDays(7);
                }
                if (IsHaveBOnFirstAppend(KickTime, KickTime.AddDays(5)))
                {
                    if (IsHaveAOnSencondApped(KickTime.AddDays(5), KickTime.AddDays(5 + 7)))
                    {
                        return KickTime.AddDays(5 + 5 + 7);
                    }
                    return KickTime.AddDays(5 + 5);
                }
                return KickTime.AddDays(5);
            }
            return KickTime;

        }
        private bool IsHaveAOnBase(DateTime start, DateTime end)
        {
            return false;
        }
        private bool IsHaveBOnBase(DateTime start, DateTime end)
        {
            return false;
        }
        private bool IsContactTwiceOnBase(DateTime start, DateTime end)
        {
            return false;
        }

        private bool IsHaveAOnFirstAppend(DateTime start, DateTime end)
        {
            return false;
        }
        private bool IsHaveBOnFirstAppend(DateTime start, DateTime end)
        {
            return false;
        }
        private bool IsHaveAOnSencondApped(DateTime start, DateTime end)
        {
            return false;
        }
    }
}

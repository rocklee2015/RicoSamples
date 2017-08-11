using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitu.Consoles.SocialInsurance
{
    public class OrderAnalysis
    {
        public List<string> AreaCodes { get; set; }

        //时间：数据
        public TimeData TimeDatas { get; set; }
    }

    public class TimeData
    {
        public Dictionary<string, AreaData> TimeDatas { get; set; }
    }

    public class AreaData
    {
        //县：数据
        public Dictionary<string, decimal> AreaDatas { get; set; }
    }



    public class OrderAnalysiMain
    {
        public static void ExcuteMain()
        {
            var areaCodes = new string[] { "县城1", "县城2", "县城3" };
            var times = new string[] { "2016-01-01", "2016-01-02", "2016-01-03" };
            var timeDatas=new Dictionary<string, TimeData>();
            foreach (string t in times)
            {
                var timeData = new TimeData();

                var areaCodeList = new Dictionary<string, AreaData>();
                for (int j = 0; j < areaCodes.Length; j++)
                {
                    var areaData = new AreaData();
                    var areaDataDic = new Dictionary<string, decimal>();
                    var price = j * 100;
                    areaDataDic.Add("工伤", price);
                    areaDataDic.Add("养老", price);
                    areaDataDic.Add("生育", price);
                    areaDataDic.Add("小计", price * 3);
                    areaData.AreaDatas = areaDataDic;
                    areaCodeList.Add(areaCodes[j], areaData);
                }
                timeData.TimeDatas = areaCodeList;
                timeDatas.Add(t, timeData);
            }
        }
    }
}

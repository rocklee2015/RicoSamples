using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S14.MaoYanMovie.Common
{
    [Flags]
    public enum Category
    {
        [Description("动作")]
        Motion = 1,

        [Description("喜剧")]
        Comedy = 2,

        [Description("爱情")]
        Love = 4,

        [Description("科幻")]
        Science = 8,

        [Description("奇幻")]
        Queer = 16,

        [Description("灾难")]
        Calamity = 32,

        [Description("恐怖")]
        Dracula = 64,

        [Description("纪录")]
        Documentary = 128,

        [Description("犯罪")]
        Crime = 256,

        [Description("战争")]
        War = 512,

        [Description("冒险")]
        Adventure = 1024,

        [Description("动画")]
        Cartoon = 2048,

        [Description("剧情")]
        Feature = 4096,

        [Description("其他")]
        Other = 8192
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rico.NetCore.EFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //asdlfjsldkfjsld
            using (var db = new RicoDbContext())
            {
                var blogs = db.Blogs
                    .Where(b => b.BlogId > 3)
                    .OrderBy(b => b.Url)
                    .ToList();
            }
        }
    }
}

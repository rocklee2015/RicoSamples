using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rico.BootstrapSamples.Models
{
    public class DepartmentModel
    {
        public string ID { set; get; }

        public string Name { set; get; }

        public string ParentName { set; get; }

        public string Level { set; get; }

        public string Desc { set; get; }
    }
}
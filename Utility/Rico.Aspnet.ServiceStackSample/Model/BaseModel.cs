using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rico.Aspnet.ServiceStackSample
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Job Job { get; set; }
    }

    public class Job
    {
        public long Id { get; set; }
        public string Position { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.MoqSample
{
    public interface ICustomer
    {

        void AddCall();

        string GetCall();

        string GetCall(string strUser);

        string GetAddress(string strUser, out string Address);

        string GetFamilyCall(ref string strUser);

        void ShowException(string str);



    }
}

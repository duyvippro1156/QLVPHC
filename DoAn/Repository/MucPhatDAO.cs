using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Repository
{
    public class MucPhatDAO
    {
        public string formatNumber(Decimal strNum)
        {
            string newNum = String.Format("{0:0,0}", (strNum));
            return newNum;
        }
    }
}
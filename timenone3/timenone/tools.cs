using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class tools
    {
        public static bool check_num(string data) // ประกาศ
        {
            bool c1 = false;
            if (System.Text.RegularExpressions.Regex.IsMatch(data, "[^0-9]"))
            {
                c1 = false;
            }
            else
            {
                c1 = true;
            }
            return c1;
        }
    }
}

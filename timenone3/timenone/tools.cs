using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timenone
{
    class tools
    {
        public static bool check_num(string data) // ประกาศ method ชื่อ check_num แบบ public โดยเป็น static คืนค่าออกมาเป็น bool โดยรับข้อมูลเป็น string
        {
            bool c1 = false; // ประกาศตัวแปร c1 เป็นข้อมูลชนิด bool มีค่าเริ่มต้นเป็น false
            if (System.Text.RegularExpressions.Regex.IsMatch(data, "[^0-9]")) // ใช้ Regex ในการเช็คว่าข้อมูลใน string ที่รับเข้ามาว่าไม่เป็นตัวเลขหรือไม่
            {
                c1 = false; // ถ้าเป็น ให้ c1 เป็น false 
            }
            else // กรณีไม่เข้าเงื่อนไขข้างบน
            {
                c1 = true; // ให้ c1 เป็น true
            }
            return c1; // คืนค่า c1
        }
    }
}
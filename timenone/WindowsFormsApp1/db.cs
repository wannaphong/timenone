/*
 * ไฟล์ db.cs
 * ใช้จัดการบันทึกเก็บข้อมูลลงไฟล์ เมื่อปิดโปรแกรม
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class db
    {
        private string path_file=""+ "db.timenone";
        private bool ok;
        public bool add_data(string[] args)
        {
            try
            {
                StreamWriter file = new StreamWriter(path_file);
                ok = true;
                foreach(string a in args)
                {
                    file.WriteLine(a);
                }
                file.Close();
            }
            catch
            {
                ok = false;
            }
            return ok;
        }
        public string show()
        {
            return "HI";
        }
    }
}

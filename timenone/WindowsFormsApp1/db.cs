/*
 * ไฟล์ db.cs
 * ใช้จัดการบันทึกเก็บข้อมูลลงไฟล์ เมื่อปิดโปรแกรม
 * 
 */
using LiteDB;
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
        //private string path_file=""+ "db.timenone";
        private bool ok;
        public string name_db= @"MyData.db";
        public string file_db()
        {
            return @"MyData.db";
        }
        public class Notifications
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string H { get; set; }
            public string M { get; set; }
            public string S { get; set; }
            public bool Sunday { get; set; }
            public bool Monday { get; set; }
            public bool Tuesday { get; set; }
            public bool Wednesday { get; set; }
            public bool Thursday { get; set; }
            public bool Friday { get; set; }
            public bool Saturday { get; set; }
            public bool IsActive { get; set; }
        }
        public bool add_data(string Title1,string H1,string M1,string S1,bool day1, bool day2, bool day3, bool day4, bool day5, bool day6, bool day7,bool IsActive1)
        {
            try
            {
                using (var db = new LiteDatabase(file_db()))
                {
                    var col = db.GetCollection<Notifications>("Notifications");
                    var data = new Notifications
                    {
                        Title = Title1,
                        H = H1,
                        M = M1,
                        S = S1,
                        Sunday = day1,
                        Monday = day2,
                        Tuesday = day3,
                        Wednesday = day4,
                        Thursday = day5,
                        Friday = day6,
                        Saturday = day7,
                        IsActive = IsActive1
                    };
                    col.Insert(data);
                    ok = true;
                }
            }
            catch (Exception e)
            {
                ok = false;
                Console.WriteLine(e);
            }
            return ok;
        }
        public void read_data()
        {
            
        }
        public string show()
        {
            return "HI";
        }
    }
}
/*
 * ไฟล์ db.cs
 * ใช้จัดการบันทึกเก็บข้อมูลลงไฟล์ เมื่อปิดโปรแกรม
 * 
 */
using LiteDB;
using System;

namespace timenone
{
    class db
    {
        private bool ok; // ประกาศตัวแปร ok เป็น bool
        public string name_db= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\timenone.db"; // กำหนดตัวแปร name_db เก็บ path ที่ใช้เก็บ timenone.db ใน MyDocuments
        public string file_db() // ประกาศ method ชื่อ file_db แบบ public คืนค่า string
        {
            return name_db; // คืนค่าตัวแปร name_db
        }
        public class Notifications // ประกาศ class แบบ public ชื่อ Notifications ใช้กับวัตถุในฐานข้อมูล
        {
            public int Id { get; set; } // ประกาศ Id เป็นข้อมูลชนิด int
            public string Title { get; set; } // ประกาศ Title เป็นข้อมูลชนิด string
            public string H { get; set; } // ประกาศ H เป็นข้อมูลชนิด string
            public string M { get; set; } // ประกาศ M เป็นข้อมูลชนิด string
            public bool Sunday { get; set; } // ประกาศ Sunday เป็นข้อมูลชนิด bool
            public bool Monday { get; set; } // ประกาศ Monday เป็นข้อมูลชนิด bool
            public bool Tuesday { get; set; } // ประกาศ Tuesday เป็นข้อมูลชนิด bool
            public bool Wednesday { get; set; } // ประกาศ Wednesday เป็นข้อมูลชนิด bool
            public bool Thursday { get; set; } // ประกาศ Thursday เป็นข้อมูลชนิด bool
            public bool Friday { get; set; } // ประกาศ Friday เป็นข้อมูลชนิด bool
            public bool Saturday { get; set; } // ประกาศ Saturday เป็นข้อมูลชนิด bool
            public bool IsActive { get; set; } // ประกาศ IsActive เป็นข้อมูลชนิด bool
        }
        public bool add_data(string Title1,string H1,string M1,bool day1, bool day2, bool day3, bool day4, bool day5, bool day6, bool day7,bool IsActive1)
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
    }
}
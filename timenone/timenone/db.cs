/*
 * ไฟล์ db.cs
 * ใช้จัดการบันทึกเก็บข้อมูลลงไฟล์ เมื่อปิดโปรแกรม
 * 
 */
using LiteDB;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace timenone
{
    class db // ประกาศ class ชื่อ db
    {
        private bool ok; // ประกาศตัวแปร ok เป็น bool
        public string name_db = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\timenone.db"; // กำหนดตัวแปร name_db เก็บ path ที่ใช้เก็บ timenone.db ใน MyDocuments
        public string name_sound = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sound.txt"; // กำหนดตัวแปร name_db เก็บ path ที่ใช้เก็บ timenone.db ใน MyDocuments
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
        public class sound // ประกาศ class แบบ public ชื่อ Notifications ใช้กับวัตถุในฐานข้อมูล
        {
            public int Id { get; set; } // ประกาศ Id เป็นข้อมูลชนิด int
            public string sound_file { get; set; } // ประกาศ Title เป็นข้อมูลชนิด string
        }
        public bool set_sound(string file)
        {
            bool t = true;
            File.WriteAllText(name_sound,file);
            /*using (var db = new LiteDatabase(file_db())) // เรียกใช้งานฐานจาก LiteDatabase(ที่ตั้งไฟล์) แล้วเก็บวัตถุไว้ในตัวแปร db
            {
                var col2 = db.GetCollection<sound>("sound");
                var productToUpdate = col2.Find(x => x.Id != 0).First();
                productToUpdate.sound_file = file;
                t = true;
                col2.Update(productToUpdate);
            }*/

            return t;
        }
        public string file_sound(string file)
        {
            string fileok="";
            if (System.IO.File.Exists(name_sound) ==false)
            {
                File.WriteAllText(name_sound, Application.StartupPath + @"\funky-breakbeat_102bpm_F_major.wav");
            }
            fileok = File.ReadAllText(name_sound);
            if (fileok == "")
                    {
                        fileok = Application.StartupPath + @"\funky-breakbeat_102bpm_F_major.wav";
                    }
            return fileok;
        } 
       public bool add_data(string Title1,string H1,string M1,bool day1, bool day2, bool day3, bool day4, bool day5, bool day6, bool day7,bool IsActive1) //ประกาศ method ชื่อ add_data แบบ public รับ string Title1,string H1,string M1,bool day1, bool day2, bool day3, bool day4, bool day5, bool day6, bool day7,bool IsActive1
        {
            try // เรียกใช้ try
            {
                using (var db = new LiteDatabase(file_db())) // เรียกใช้งานฐานจาก LiteDatabase(ที่ตั้งไฟล์) แล้วเก็บวัตถุไว้ในตัวแปร db
                {
                    var col = db.GetCollection<Notifications>("Notifications"); // ประกาศตัวแปร col แทน db.GetCollection<Notifications>("Notifications")
                    var data = new Notifications // กำหนดตัวแปร data ให้แทน Notifications
                    {
                        Title = Title1, // ให้ Title = Title1
                        H = H1,// ให้ H = H1
                        M = M1,// ให้ M = M1
                        Sunday = day1,// ให้ Sunday = day1
                        Monday = day2,// ให้ Monday = day2
                        Tuesday = day3,// ให้ Tuesday = day3
                        Wednesday = day4,// ให้ Wednesday = day4
                        Thursday = day5,// ให้ Thursday = day5
                        Friday = day6,// ให้ Friday = day6
                        Saturday = day7,// ให้ Saturday = day7
                        IsActive = IsActive1// ให้ IsActive = IsActive1
                    };
                    col.Insert(data); // เพิ่มข้อมูลลงฐานข้อมูล
                    ok = true; // ให้ ok เป็น true
                    
                }
            }
            catch (Exception e) // กรณีมีข้อผิดพลาด ให้เก็บรายละเอียดของข้อมูลผิดพลาดไว้ใน e
            {
                ok = false; // ให้ ok เป็น false
                Console.WriteLine(e); // แสดงข้อผิดพลาดที่ได้จาก e ใน Console
            }
            return ok; // คืนค่า ok
        }
    }
}
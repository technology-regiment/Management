//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Background.Entities;

//namespace Background.Data
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var db = new BackgroundDbContext())
//            {
//                User b = new User();
//                Console.WriteLine("请输入姓名");
//                b.Name = Console.ReadLine();
//                db.UserContext.Add(b);
//                db.SaveChanges();
//            }
//        }
//    }
//}

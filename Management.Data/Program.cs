//using Management.Data.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Management.Data
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var db = new ManagementContext())
//            {
//                Book b = new Book();
//                Console.WriteLine("请输入图书的姓名");
//                b.Name = Console.ReadLine();
//                Console.WriteLine("请输入图书的种类");
//                b.Class = Console.ReadLine();

//                db.BookContext.Add(b);
//                db.SaveChanges();
//                var query = from t in db.BookContext orderby t.Name select t;
//                foreach (var item in query)
//                {
//                    Console.WriteLine(string.Format("{0}", item.Name));
//                    Console.WriteLine();
//                }

//            }
//        }
//    }
//}

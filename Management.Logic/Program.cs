using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Management.Data.Model;
using Management.ILogic;

namespace Management.Logic
{
    public class Program
    {
        private readonly IBookLogic _bookLogic;
        public Program(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }

        public Program()
        {
        }

        public  void Create(Book book)
        {
            _bookLogic.Create(book);
        }
    }
}

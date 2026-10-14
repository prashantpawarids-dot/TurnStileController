using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_CSharp
{
    public class clsCommon
    {
        public uint UserId { get; set; }
        public string UserName { get; set; }
        public string CardNo { get; set; }
        public string EmployeeID { get; set; }
    }

    public class clsReader
    {
        public int ID { get; set; }
        public string code { get; set; }
        public string readerip { get; set; }
        public string readerport { get; set; }
        public string readermode { get; set; }
        public string readerLocation { get; set; }
        public string readertype { get; set; }
        public string isActive { get; set; }
        public string IsDeleted { get; set; }
    }
}

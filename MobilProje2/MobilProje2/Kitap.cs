using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobilProje2
{
    public class Kitap
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string İsim { get; set; }

        public string Yazar { get; set; }
    }
}

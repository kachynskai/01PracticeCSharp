using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp.Practice1.Model
{
    class UserHoroscope
    {
        private DateTime _birthDay;
        private int _age;
        private string _westernSign = string.Empty;
        private string _chineseSign = string.Empty;


        public int Age { get => _age; set => _age = value; }
        public string WesternSign { get => _westernSign; set => _westernSign = value; }
        public string ChineseSign { get => _chineseSign; set => _chineseSign = value; }
        public DateTime BirthDay { get => _birthDay; set => _birthDay = value; }
    }
}

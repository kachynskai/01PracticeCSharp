using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp.Practice1.Model
{
    class UserHoroscope
    {
        private DateTime? _birthDay;
      
        public DateTime? BirthDay { get => _birthDay; set => _birthDay = value; }
    }
}

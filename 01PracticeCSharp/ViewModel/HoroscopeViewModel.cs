using CommunityToolkit.Mvvm.Input;
using KMA.ProgrammingInCSharp.Practice1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp.Practice1.ViewModel
{
    class HoroscopeViewModel
    {
        private readonly UserHoroscope _user = new();
        private RelayCommand _command;

        public string WesternSign
        {
            get { return _user.WesternSign; }
            set { _user.WesternSign = value; }
        }
        public string ChineseSign
        {
            get { return _user.ChineseSign; }
            set { _user.ChineseSign = value; }
        }

        public int Age {  get { return _user.Age; } set { _user.Age = value; }}

        public DateTime BirthDate { get { return _user.BirthDay; } set { _user.BirthDay = value; }}

        public string ChineseSignRes => CalculateChineseSign();
        public string WesternSignRes => CalculateWestermSign();

        private string CalculateWestermSign()
        {
            string[] zodiacSigns = {
        "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo",
        "Libra", "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pisces"};

            int[] zodiacStartDays = { 21, 20, 21, 21, 23, 23, 23, 23, 22, 22, 20, 19 };

            int month = BirthDate.Month;
            int day = BirthDate.Day;

            return day < zodiacStartDays[(month + 9) % 12] ? zodiacSigns[(month + 8) % 12] : zodiacSigns[(month + 9) % 12];
        }

        private string CalculateChineseSign()
        {
            int year = BirthDate.Year;
            string[] chineseZodiacSigns = { "Mouse", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep", "Monkey", "Cock", "Dog", "Pig" };
            return chineseZodiacSigns[(year-4) % 12];
        }


        //public RelayCommand Command
        //{
        //    get
        //    {
        //        return _command ??= new RelayCommand(CalculateSigns, CanCalculateSigns);
        //    }
        //}

        private bool CanCalculateSigns()
        {
            //return BirthDay != null;
            return true;
        }

        private void CalculateSigns()
        {
           
        }
    }
    
}

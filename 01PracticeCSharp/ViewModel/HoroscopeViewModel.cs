using CommunityToolkit.Mvvm.Input;
using KMA.ProgrammingInCSharp.Practice1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.ProgrammingInCSharp.Practice1.ViewModel
{
    class HoroscopeViewModel: INotifyPropertyChanged
    {
        private readonly UserHoroscope _user = new();
        private RelayCommand? _calculateSignsCommand;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DateTime? BirthDate
        {
            get { return _user.BirthDay; }
            set {
                if (_user.BirthDay != value)
                {
                    _user.BirthDay = value;
                    OnPropertyChanged(nameof(BirthDate));
                    OnPropertyChanged(nameof(Age));
                    WesternSign = string.Empty;
                    ChineseSign = string.Empty;
                    OnPropertyChanged(nameof(WesternSign));
                    OnPropertyChanged(nameof(ChineseSign));

                    CalculateSignsCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public int? Age => CalculateAge();
        public string WesternSign { get; private set; } = string.Empty;
        public string ChineseSign { get; private set; } = string.Empty;

        private int? CalculateAge()
        {
            if(BirthDate == null)
                return null;
            DateTime today = DateTime.Now;
            int age = today.Year - BirthDate.Value.Year;
            if (BirthDate.Value.Date > today.AddYears(-age))
            {
                age--;
            }

            if (age > 135 || BirthDate > today)
            {
                MessageBox.Show("You entered invalid Date!", "Exeption!", MessageBoxButton.OK, MessageBoxImage.Error);
                BirthDate = null;
                return null;
            }
            if (BirthDate.Value.Day == today.Day && BirthDate.Value.Month == today.Month)
            {
                MessageBox.Show("Congrats with ur birthdayyy! It seems like we have a party today!", "Woow, it's a ur day!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            
            return age;
        }

        private string CalculateWesternSign()
        {
            if (BirthDate == null)
                return string.Empty;

            string[] zodiacSigns = {
            "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini",
            "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius"
            };


            int[] zodiacStartDays = { 20, 19, 21, 20, 21, 21, 23, 23, 23, 23, 22, 22 };

            int month = BirthDate.Value.Month;
            int day = BirthDate.Value.Day;

            return (day < zodiacStartDays[month - 1]) ? zodiacSigns[month - 1] : zodiacSigns[month % 12];
        }

        private string CalculateChineseSign()
        {
            if (BirthDate == null)
                return string.Empty;
            int year = BirthDate.Value.Year;
            string[] chineseZodiacSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
            return chineseZodiacSigns[(year-4) % 12];
        }


        public RelayCommand CalculateSignsCommand
        {
            get
            {
                return _calculateSignsCommand ??= new RelayCommand(CalculateSigns, CanCalculateSigns);
            }
        }

        private bool CanCalculateSigns()
        {
            return BirthDate != null;
          
        }

        private void CalculateSigns()
        {
            WesternSign = CalculateWesternSign();
            ChineseSign = CalculateChineseSign();
            OnPropertyChanged(nameof(WesternSign));
            OnPropertyChanged(nameof(ChineseSign));
        }
    }
    
}

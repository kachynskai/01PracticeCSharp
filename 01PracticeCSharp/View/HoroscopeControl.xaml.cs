using KMA.ProgrammingInCSharp.Practice1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KMA.ProgrammingInCSharp.Practice1.View
{
    /// <summary>
    /// Interaction logic for HoroscopeControl.xaml
    /// </summary>
    public partial class HoroscopeControl : UserControl
    {
        private HoroscopeViewModel _model;
        public HoroscopeControl()
        {
            InitializeComponent();
            DataContext = _model = new HoroscopeViewModel();
        }
    }
}

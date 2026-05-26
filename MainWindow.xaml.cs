using Microsoft.Win32;
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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void showDateAndHour()
        {
            HourTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            DateTextBlock.Text = DateTime.Today.ToString("dd:MM:yy");
        }

        private void ClockButtonClick(object sender, RoutedEventArgs e)
        {
            ClockPage.Visibility = Visibility.Visible;
            AlarmPage.Visibility = Visibility.Collapsed;
            TimerPage.Visibility = Visibility.Collapsed;
        }

        private void AlarmButtonClick(object sender, RoutedEventArgs e)
        {
            ClockPage.Visibility = Visibility.Collapsed;
            AlarmPage.Visibility = Visibility.Visible;
            TimerPage.Visibility = Visibility.Collapsed;
        }

        private void TimerButtonClick(object sender, RoutedEventArgs e)
        {
            ClockPage.Visibility = Visibility.Collapsed;
            AlarmPage.Visibility = Visibility.Collapsed;
            TimerPage.Visibility = Visibility.Visible;
        }
    }
}

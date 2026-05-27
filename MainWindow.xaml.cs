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
using System.Windows.Threading;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {

            InitializeComponent();
            applyColorMode();
            showDateAndHour();

            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += Timer_Tick;

            timer.Start();
        }
        private void showDateAndHour()
        {
            HourTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            DateTextBlock.Text = DateTime.Today.ToString("dd/MM/yy");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            showDateAndHour();
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

        private bool isDarkMode()
        {
            object value = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1);
            return (int)value == 0;
        }

        private void applyColorMode()
        {
            if (isDarkMode())
            {
                SolidColorBrush backgroundDarkColor = new SolidColorBrush(Color.FromRgb(24, 24, 24));
                SolidColorBrush backgroundDarkColorDarker = new SolidColorBrush(Color.FromRgb(20, 20, 20));
                MainGrid.Background = backgroundDarkColor;
                SidebarClockButton.Background = backgroundDarkColor;
                SidebarAlarmButton.Background = backgroundDarkColor;
                SidebarTimerButton.Background = backgroundDarkColor;
                SideBar.Background = backgroundDarkColorDarker;
                SidebarClockButton.Foreground = Brushes.White;
                SidebarAlarmButton.Foreground = Brushes.White;
                SidebarTimerButton.Foreground = Brushes.White;
                HourTextBlock.Foreground = Brushes.White;
                DateTextBlock.Foreground = Brushes.White;
            }
            else
            {
                SolidColorBrush backgroundWhiteColorDarker = new SolidColorBrush(Color.FromRgb(211, 211, 211));
                MainGrid.Background = Brushes.White;
                SidebarClockButton.Background = Brushes.White;
                SidebarAlarmButton.Background = Brushes.White;
                SidebarTimerButton.Background = Brushes.White;
                SidebarClockButton.Foreground = Brushes.Black;
                SidebarAlarmButton.Foreground = Brushes.Black;
                SidebarTimerButton.Foreground = Brushes.Black;
                HourTextBlock.Foreground = Brushes.Black;
                DateTextBlock.Foreground = Brushes.Black;
            }
        }
    }
}

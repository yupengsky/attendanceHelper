using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace attendanceHelper
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer flowTimer;
        private List<string> nameList;

        public MainWindow()
        {
            InitializeComponent();
            nameList = new List<string>
            {
                NameBox1.Text,
                NameBox2.Text,
                NameBox3.Text,
                NameBox4.Text,
                NameBox5.Text
            };
            flowTimer = new DispatcherTimer();
            flowTimer.Interval = TimeSpan.FromMilliseconds(100); // 更快的滚动速度
            flowTimer.Tick += FlowTimer_Tick;
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            int speed = 10;
            if (int.TryParse(SpeedBox.Text, out int value) && value > 0)
            {
                speed = value;
            }
            flowTimer.Interval = TimeSpan.FromMilliseconds(speed);
            flowTimer.Start();
        }

        private void FlowTimer_Tick(object sender, EventArgs e)
        {
            // Move last to first (right shift)
            var last = nameList[nameList.Count - 1];
            nameList.RemoveAt(nameList.Count - 1);
            nameList.Insert(0, last);
            NameBox1.Text = nameList[0];
            NameBox2.Text = nameList[1];
            NameBox3.Text = nameList[2];
            NameBox4.Text = nameList[3];
            NameBox5.Text = nameList[4];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flowTimer.Stop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void NameBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

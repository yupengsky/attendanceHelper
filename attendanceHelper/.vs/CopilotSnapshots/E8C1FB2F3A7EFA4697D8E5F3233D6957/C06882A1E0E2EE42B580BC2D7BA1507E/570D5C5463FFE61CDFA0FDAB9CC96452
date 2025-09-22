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
using Microsoft.Win32;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace attendanceHelper
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer flowTimer;
        private List<string> nameList;
        private List<string> timeList;

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
            timeList = new List<string>();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // IMPORT button click
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(stream);
                    ISheet sheet = workbook.GetSheetAt(0);
                    var maxNames = 150;
                    var maxTimes = 50;
                    nameList.Clear();
                    timeList.Clear();
                    // 读取时间行（第一行，去掉A1）
                    IRow timeRow = sheet.GetRow(0);
                    for (int i = 1; i < Math.Min(timeRow.LastCellNum, maxTimes + 1); i++)
                    {
                        var cell = timeRow.GetCell(i);
                        if (cell != null)
                            timeList.Add(cell.ToString());
                    }
                    // 读取姓名列（第一列，去掉A1）
                    for (int i = 1; i < Math.Min(sheet.LastRowNum + 1, maxNames + 1); i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row != null)
                        {
                            var cell = row.GetCell(0);
                            if (cell != null)
                                nameList.Add(cell.ToString());
                        }
                    }
                    // 刷新姓名流动区
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < nameList.Count)
                        {
                            switch (i)
                            {
                                case 0: NameBox1.Text = nameList[0]; break;
                                case 1: NameBox2.Text = nameList[1]; break;
                                case 2: NameBox3.Text = nameList[2]; break;
                                case 3: NameBox4.Text = nameList[3]; break;
                                case 4: NameBox5.Text = nameList[4]; break;
                            }
                        }
                    }
                    // 刷新时间下拉区
                    timelist.Items.Clear();
                    foreach (var t in timeList)
                    {
                        timelist.Items.Add(t);
                    }
                    if (timelist.Items.Count > 0)
                        timelist.SelectedIndex = 0;
                }
            }
        }

        private void SpeedBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TimeClock.model;
using System.Threading;
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace TimeClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool IsLocked = true;

        DateTimer dateTimer;
        public MainWindow()
        {
            //设置动画帧数为1
            Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = 1 });
            //没啥卵用不敲了
            
            InitializeComponent();
            
            dateTimer = new DateTimer();
            dateTimer.Week = DateTime.Now.DayOfWeek.ToString();
            dateTimer.LongLi = SolarToChineseLunisolarDate(DateTime.Today);
            dateTimer.ShortDate = DateTime.Today.ToShortDateString();
            StartWork();
            this.DataContext = dateTimer;
        }

        private string SolarToChineseLunisolarDate(DateTime solarDateTime)
        {
            System.Globalization.ChineseLunisolarCalendar cal = new System.Globalization.ChineseLunisolarCalendar();

            int year = cal.GetYear(solarDateTime);
            int month = cal.GetMonth(solarDateTime);
            int day = cal.GetDayOfMonth(solarDateTime);
            int leapMonth = cal.GetLeapMonth(year);
            return string.Format("农历{0}{1}({2})年{3}{4}月{5}{6}"
            , "甲乙丙丁戊己庚辛壬癸"[(year - 4) % 10]
            , "子丑寅卯辰巳午未申酉戌亥"[(year - 4) % 12]
            , "鼠牛虎兔龙蛇马羊猴鸡狗猪"[(year - 4) % 12]
            , month == leapMonth ? "闰" : ""
            , "无正二三四五六七八九十冬腊"[leapMonth > 0 && leapMonth <= month ? month - 1 : month]
            , "初十廿三"[day / 10]
            , "日一二三四五六七八九"[day % 10]
            );
        }

      
        private async void StartWork()
        {
            await Task.Run(() =>{
                while (true)
                {
                    var dateNow = DateTime.Now;
                    if(!string.Equals(dateTimer.ShortDate,dateNow.ToShortDateString()))
                    {
                        dateTimer.ShortDate = dateNow.ToShortDateString();
                        dateTimer.LongLi = SolarToChineseLunisolarDate(DateTime.Today);
                    }
                    dateTimer.Hour = dateNow.Hour;
                    dateTimer.Minute = dateNow.Minute;
                    dateTimer.Second = dateNow.Second;
                    dateTimer.DateNow = string.Format("{0}:{1}", dateNow.Hour.ToString().PadLeft(2,'0'), dateNow.Minute.ToString().PadLeft(2,'0'));
                    Thread.Sleep(1000);
                }
            });
            
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (IsLocked==false)
            {
                this.DragMove();
            }
        }

        private void close_Window(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void canClose_Window(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Locker_Click(object sender, RoutedEventArgs e)
        {
            if (IsLocked==false)
            {
                IsLocked = true;
                this.Locker.Content = "";
            }
            else
            {
                IsLocked = false;
                this.Locker.Content = "";
            }
            

        }
    }
}

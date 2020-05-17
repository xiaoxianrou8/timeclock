using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClock.model
{
    public class Weather : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged=(sender,e)=> { };
        private string temp;

        public string Temp
        {
            get { return temp; }
            set { temp = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Temp)));
            }
        }

        private string todayWeather;

        public string TodayWeather
        {
            get { return todayWeather; }
            set { todayWeather = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(TodayWeather)));
            }
        }


    }
}

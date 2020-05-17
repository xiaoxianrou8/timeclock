using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClock.model
{
    public class DateTimer : INotifyPropertyChanged
    {
        private string dateNow;

        public string DateNow
        {
            get { return dateNow; }
            set { dateNow = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(dateNow)));
            }
        }

        private string longLi;

        public string LongLi
        {
            get { return longLi; }
            set { longLi = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(LongLi)));
            }
        }

        private string week;

        public string Week
        {
            get { return week; }
            set { week = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Week)));
            }
        }

        private string shortDate;

        public string ShortDate
        {
            get { return shortDate; }
            set { shortDate = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(ShortDate)));
            }
        }

        private int second;

        public int Second
        {
            get { return second; }
            set { second = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Second)));
            }
        }

        private int hour;

        public int Hour
        {
            get { return hour; }
            set { hour = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Hour)));
            }
        }

        private int minute;

        public int Minute
        {
            get { return minute; }
            set { minute = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Minute)));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged=(sender,e)=> { };
    }
}

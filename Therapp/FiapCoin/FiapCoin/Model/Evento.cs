using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace THERAPP.Model
{
    public class Evento : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _id;

        [PrimaryKey]
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _calendar_id;
        public int calendar_id
        {
            get { return _calendar_id; }
            set
            {
                if (_calendar_id != value)
                {
                    _calendar_id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String _title;
        public String title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String _description;
        public String description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String _start;
        public String start
        {
            get { return _start; }
            set
            {
                if (_start != value)
                {
                    _start = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime _date;
        public DateTime date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Evento()
        {

        }

        public Evento(int _id, int _calendar_id, String _title, String _description, String _start)
        {
            this.id = _id;
            this.calendar_id = _calendar_id;
            this.title = _title;
            this.description = _description;
            this.start = _start;
        }

        public Evento(int _id, int _calendar_id, String _title, String _description, String _start, DateTime _date)
        {
            this.id = _id;
            this.calendar_id = _calendar_id;
            this.title = _title;
            this.description = _description;
            this.start = _start;
            this.date = _date;
        }

        public Evento(int _id, int _calendar_id, String _title, String _start)
        {
            this.id = _id;
            this.calendar_id = _calendar_id;
            this.title = _title;
            this.start = _start;
        }
    }
}

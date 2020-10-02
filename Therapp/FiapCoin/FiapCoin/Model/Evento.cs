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

        private int idEvento;

        [PrimaryKey]
        public int IdEvento
        {
            get { return idEvento; }
            set
            {
                if (idEvento != value)
                {
                    idEvento = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int idCalendar;
        public int IdCalendar
        {
            get { return idCalendar; }
            set
            {
                if (idCalendar != value)
                {
                    idCalendar = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String title;
        public String Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String description;
        public String Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime start;
        public DateTime Start
        {
            get { return start; }
            set
            {
                if (start != value)
                {
                    start = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Evento()
        {

        }

        public Evento(int _idEvento, int _idCalendar, String _title, String _description, DateTime _start)
        {
            this.IdEvento = _idEvento;
            this.IdCalendar = _idCalendar;
            this.Title = _title;
            this.Description = _description;
            this.Start = _start;
        }

        public Evento(int _idEvento, int _idCalendar, String _title, DateTime _start)
        {
            this.IdEvento = _idEvento;
            this.IdCalendar = _idCalendar;
            this.Title = _title;
            this.Start = _start;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.Demos.Models
{
    public class User : INotifyPropertyChanged
    {
        //Expose Event to External Classes
        //02 PropertyChanged is not not null
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    //Raise Event
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

       

        private void NotifyPropertyChanged(string propName)
        {
            //Somone Else Register the Event
           if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}

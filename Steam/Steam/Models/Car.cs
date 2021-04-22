using Steam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models
{
    class Car : BaseNotifyPropertyChanged
    {
        string title;
        string mark;
        string photo;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                Notify();
            }
        }

        public string Mark
        {
            get => mark;
            set
            {
                mark = value;
                Notify();
            }
        }
        public string Photo
        {
            get => photo;
            set
            {
                photo = value;
                Notify();
            }
        }
    }
}

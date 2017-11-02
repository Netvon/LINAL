using LINAL.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LINAL.View.Model
{
    public class Line2d : INotifyPropertyChanged
    {
        Point3 origin;
        Vector3 vector;

        public Point3 Origin
        {
            get => origin;

            set
            {
                origin = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(XComponent));
                OnPropertyChanged(nameof(YComponent));
            }
        }

        public Vector3 Vector
        {
            get => vector;

            set
            {
                vector = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(XComponent));
                OnPropertyChanged(nameof(YComponent));
            }
        }

        public Point3 XComponent => Origin.Offsets(Vector).ElementAt(0);
        public Point3 YComponent => Origin.Offsets(Vector).ElementAt(1);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

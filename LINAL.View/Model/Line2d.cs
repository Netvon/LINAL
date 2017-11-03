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
        double scale = 1.0;

        Point3 xComponent;
        Point3 yComponent;

        string name;

        public Point3 Origin
        {
            get => origin;

            set
            {
                origin = value;
                Update();
            }
        }

        public Vector3 Vector
        {
            get => vector;

            set
            {
                vector = value;
                Update();
            }
        }

        public double Scale
        {
            get => scale;
            set
            {
                scale = value;
                if (scale < Double.Epsilon)
                    scale = Double.Epsilon;

                Update();
            }
        }

        public double VectorX
        {
            get => Vector.X;
            set
            {
                Vector.X = value;

                OnPropertyChanged();
                Update();
            }
        }

        public double VectorY
        {
            get => Vector.Y;
            set
            {
                Vector.Y = value;

                OnPropertyChanged();
                Update();
            }
        }

        public double OriginX
        {
            get => Origin.X;
            set
            {
                Origin.X = value;

                OnPropertyChanged();
                Update();
            }
        }

        public double OriginY
        {
            get => Origin.Y;
            set
            {
                Origin.Y = value;

                OnPropertyChanged();
                Update();
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }


        public Point3 XComponent => xComponent;
        public Point3 YComponent => yComponent;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void Update()
        {
            if (Vector != null)
            {
                xComponent = Origin?.Offsets(Vector * Scale).ElementAt(0);
                yComponent = Origin?.Offsets(Vector * Scale).ElementAt(1);

                OnPropertyChanged(nameof(XComponent));
                OnPropertyChanged(nameof(YComponent));
            }

            OnPropertyChanged(nameof(Scale));
            OnPropertyChanged(nameof(Origin));
            OnPropertyChanged(nameof(Vector));
            
        }
    }
}

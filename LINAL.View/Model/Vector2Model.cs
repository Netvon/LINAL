using LINAL.Types;
using LINAL.Types.Points;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LINAL.View.Model
{
    public class Vector2Model : Drawable
    {
        Point3 origin;
        Vector3 vector;
        double scale = 1.0;

        Point3 xComponent;
        Point3 yComponent;
        Point3 directionComponent;

        public Vector2Model() : base("vector")
        { }

        public Point3 Origin
        {
            get => origin;

            set
            {
                origin = value;
                Changed();
            }
        }

        public Vector3 ScaledVector => Vector * Scale;

        public Vector3 Vector
        {
            get => vector;

            set
            {
                vector = value;
                Changed();
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

                Changed();
            }
        }

        public double VectorX
        {
            get => Vector.X;
            set
            {
                Vector.X = value;

                OnPropertyChanged();
                Changed();
            }
        }

        public double VectorY
        {
            get => Vector.Y;
            set
            {
                Vector.Y = value;

                OnPropertyChanged();
                Changed();
            }
        }

        public double OriginX
        {
            get => Origin.X;
            set
            {
                Origin.X = value;

                OnPropertyChanged();
                Changed();
            }
        }

        public double OriginY
        {
            get => Origin.Y;
            set
            {
                Origin.Y = value;

                OnPropertyChanged();
                Changed();
            }
        }

        public Point3 XComponent => xComponent;
        public Point3 YComponent => yComponent;
        public Point3 DirectionComponent => directionComponent;

        void Changed()
        {
            if (Vector != null)
            {
                xComponent = Origin?.Offsets(Vector * Scale).ElementAt(0);
                yComponent = Origin?.Offsets(Vector * Scale).ElementAt(1);

                directionComponent = new Point3(xComponent.X, yComponent.Y, 0);

                OnPropertyChanged(nameof(XComponent));
                OnPropertyChanged(nameof(YComponent));
                OnPropertyChanged(nameof(DirectionComponent));
            }

            OnPropertyChanged(nameof(Scale));
            OnPropertyChanged(nameof(Origin));
            OnPropertyChanged(nameof(Vector));
            OnPropertyChanged(nameof(ScaledVector));
        }
    }
}

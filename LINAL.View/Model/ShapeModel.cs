using LINAL.Types;
using LINAL.Types.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LINAL.View.Model
{
    public class ShapeModel : Drawable
    {
        CancellationTokenSource spinCancelToken;
        bool spin;

        public Shape Shape { get; }
        public ShapeModel(Shape shape) : base("shape")
        {
            Shape = shape;
        }

        public double LocationX
        {
            get => Shape.Translate.X;
            set
            {
                Shape.Translate.X = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double LocationY
        {
            get => Shape.Translate.Y;
            set
            {
                Shape.Translate.Y = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double Rotation
        {
            get => Shape.Rotation;
            set
            {
                Shape.Rotation = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double SkewX
        {
            get => Shape.Skew.X;
            set
            {
                Shape.Skew.X = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double SkewY
        {
            get => Shape.Skew.Y;
            set
            {
                Shape.Skew.Y = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double Width
        {
            get => Shape.Size.X;
            set
            {
                Shape.Size.X = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double Height
        {
            get => Shape.Size.Y;
            set
            {
                Shape.Size.Y = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double ScaleX
        {
            get => Shape.Scale.X;
            set
            {
                Shape.Scale.X = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double ScaleY
        {
            get => Shape.Scale.Y;
            set
            {
                Shape.Scale.Y = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public bool Spin
        {
            get => spin;

            set
            {
                if (spin == value)
                    return;

                if(value)
                {
                    spinCancelToken?.Cancel();
                    spinCancelToken = new CancellationTokenSource();

                    var token = spinCancelToken.Token;

                    Task.Factory.StartNew(async () =>
                    {
                        while(!token.IsCancellationRequested)
                        {
                            await Task.Delay(1, token);
                            Rotation++;
                        }
                    }, token);
                } else
                {
                    spinCancelToken?.Cancel();
                }

                spin = value;
            }
        }

        void Changed()
        {
            OnPropertyChanged(nameof(Points));
            OnPropertyChanged(nameof(PointCollection));
        }

        public IEnumerable<Point3> Points => Shape.ToList();

        public PointCollection PointCollection => new PointCollection(Shape.Select(p => new Point(p.X, p.Y)));
    }
}

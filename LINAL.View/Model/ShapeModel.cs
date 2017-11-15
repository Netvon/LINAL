using LINAL.Types;
using LINAL.Types.Points;
using LINAL.Types.Shapes;
using LINAL.Types.Transforms;
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

        public Shape2D Shape { get; }
        public ShapeModel(Shape2D shape) : base("shape")
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

        public Point3 Center => CalcPoint(Shape.Center);
        public double CenterX => Center.X;
        public double CenterY => Center.Y;

        public LINAL.Types.Matrices.Matrix Matrix => Shape.MultipliedMatrix;

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
            OnPropertyChanged(nameof(Center));
            OnPropertyChanged(nameof(CenterX));
            OnPropertyChanged(nameof(CenterY));
            OnPropertyChanged(nameof(Matrix));
            OnPropertyChanged(nameof(MultipliedMatrix));
        }

        Translate2D CameraOffset { get; } = new Translate2D
        {
            X = 0,
            Y = 0
        };

        public double CameraOffsetX
        {
            get => CameraOffset.X;
            set
            {
                CameraOffset.X = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double CameraOffsetY
        {
            get => CameraOffset.Y;
            set
            {
                CameraOffset.Y = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double CameraRotationZ
        {
            get => CameraRotation.Z;
            set
            {
                CameraRotation.Z = value;
                OnPropertyChanged();
                Changed();
            }
        }

        Rotate2D CameraRotation { get; } = new Rotate2D
        {
            Z = 0
        };

        Point2 CameraCenter { get; } = new Point2(100, 100);

        public double CameraCenterX
        {
            get => CameraCenter.X;
            set
            {
                CameraCenter.X = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public double CameraCenterY
        {
            get => CameraCenter.Y;
            set
            {
                CameraCenter.Y = value;
                OnPropertyChanged();
                Changed();
            }
        }

        public IEnumerable<Point3> Points
        {
            get
            {
                //var pi = CameraCenter.ToIdentity();
                //var npi = CameraCenter.ToNegatedIdentity();

                //var translate2D = new Translate2D
                //{
                //    X = 0,
                //    Y = 0
                //};

                //var rotate2D = new Rotate2D
                //{
                //    Z = 0
                //};

                return Shape.Select(CalcPoint).ToList();
            }
        }

        Point3 CalcPoint(Point3 point)
        {
            var pi = CameraCenter.ToIdentity();
            var npi = CameraCenter.ToNegatedIdentity();

            return new Point3(pi * CameraRotation * npi * CameraOffset * point);
        }

        public PointCollection PointCollection => new PointCollection(Points.Select(p => new System.Windows.Point(p.X, p.Y)));

        public Types.Matrices.Matrix MultipliedMatrix => Shape.MultipliedMatrix;
    }
}

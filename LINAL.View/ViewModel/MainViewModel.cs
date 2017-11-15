using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LINAL.Types;
using LINAL.Types.Points;
using LINAL.Types.Projection;
using LINAL.Types.Shapes;
using LINAL.Types.Vectors;
using LINAL.View.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LINAL.View.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public int StrokeSize { get; set; }
        public ObservableCollection<Drawable> Drawables { get; }

        Camera3 camera = new Camera3()
        {
            Eye = new Point3(0, 0, 0),
            LookAt = new Point3(0, 0, 1),
            Near = 2,
            Far = 100,
            FieldOfView = 45,
            Size = 500
        };

        public IEnumerable<Point3> PointsThroughCamera
        {
            get
            {
                return Drawables
                    .OfType<Shape3DModel>()
                    .SelectMany(x => x.Points)
                    .Select(camera.Transform)
                    .Where(x => x.W > 0)
                    .Select(x => new Point3(x.X, x.Y, x.Z));
            }
        }

        public ICommand LineMouseOverCommand => new RelayCommand<string>(OnLineMouseOver);
        public ICommand AddVectorCommand => new RelayCommand(AddVector);
        public ICommand AddBoxCommand => new RelayCommand(AddBox);
        public ICommand AddTriangleCommand => new RelayCommand(AddTriangle);
        public ICommand RemoveVectorCommand => new RelayCommand<string>(RemoveVector);
        public ICommand RemoveBoxCommand => new RelayCommand<string>(RemoveBox);
        public ICommand SomethingChanged => new RelayCommand<object>(Something);

        private void Something(object obj)
        {

            if(obj is RoutedEventArgs routed && routed.Source is FrameworkElement source)
            {
                CameraCenterX = source.ActualWidth / 2;
                CameraCenterY = source.ActualHeight / 2;

                CameraOffsetX = CameraCenterX;
                CameraOffsetY = CameraCenterY;

                //camera.LookAt = new Point3(0, 0, CameraCenterY);
                //camera.Size = source.ActualWidth;

                RaisePropertyChanged(nameof(PointsThroughCamera));
            }
        }

        public int ViewWidth { get; set; }
        public int ViewHeight { get; set; }

        double cameraRot;
        double cameraOffsetX;
        double cameraOffsetY;
        double cameraCenterX = 100;
        double cameraCenterY = 100;

        public double CameraRotationZ
        {
            get => cameraRot;
            set
            {
                foreach (var d in Drawables)
                {
                    if(d is ShapeModel s)
                    {
                        s.CameraRotationZ = value;
                    }
                }

                cameraRot = value;
                RaisePropertyChanged();
            }
        }

        public double CameraCenterX
        {
            get => cameraCenterX;
            set
            {
                foreach (var d in Drawables)
                {
                    if (d is ShapeModel s)
                    {
                        s.CameraCenterX = value;
                    }
                }

                cameraCenterX = value;
                RaisePropertyChanged();
            }
        }

        public double CameraCenterY
        {
            get => cameraCenterY;
            set
            {
                foreach (var d in Drawables)
                {
                    if (d is ShapeModel s)
                    {
                        s.CameraCenterY = value;
                    }
                }

                cameraCenterY = value;
                RaisePropertyChanged();
            }
        }

        public double CameraOffsetX
        {
            get => cameraOffsetX;
            set
            {
                foreach (var d in Drawables)
                {
                    if (d is ShapeModel s)
                    {
                        s.CameraOffsetX = value;
                    }
                }

                cameraOffsetX = value;
                RaisePropertyChanged();
            }
        }

        public double CameraOffsetY
        {
            get => cameraOffsetY;
            set
            {
                foreach (var d in Drawables)
                {
                    if (d is ShapeModel s)
                    {
                        s.CameraOffsetY = value;
                    }
                }

                cameraOffsetY = value;

                RaisePropertyChanged();
            }
        }

        void AddTriangle()
        {
            Drawables.Add(new ShapeModel(new Triangle(0, 0, 10, 10))
            {
                Name = $"Triangle {Drawables.Count(d => d.Category.Equals("shape")) + 1}",
            });
        }

        void AddVector()
        {
            Drawables.Add(new Vector2Model()
            {
                Name = $"Vector {Drawables.Count(d => d.Category.Equals("vector")) + 1}",
                Origin = new Point3(0, 0, 0),
                Vector = new Vector3(20, 20, 0)
            });
        }

        void AddBox()
        {
            Drawables.Add(new ShapeModel(new Box(0, 0, 10, 10))
            {
                Name = $"Box {Drawables.Count(d => d.Category.Equals("shape")) + 1}",
            });
        }

        void RemoveVector(string obj)
        {
            Drawables.Remove(Drawables.FirstOrDefault(x => x.Name == obj && x.Category.Equals("vector")));
        }

        void RemoveBox(string obj)
        {
            Drawables.Remove(Drawables.FirstOrDefault(x => x.Name == obj && x.Category.Equals("shape")));
        }

        void OnLineMouseOver(string obj)
        {
            var line = Drawables.FirstOrDefault(x => x.Name == obj);

            if(line != null)
                line.ShowLabel = !line.ShowLabel;
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Drawables = new ObservableCollection<Drawable>()
            {
                //new Vector2Model()
                //{
                //    Name = "Vector 1",
                //    Origin = new Point3(10,10,0),
                //    Vector = new Vector3(20,20,0)
                //},

                //new Vector2Model()
                //{
                //    Name = "Vector 2",
                //    Origin = new Point3(40,10,0),
                //    Vector = new Vector3(20,20,0)
                //},

                //new ShapeModel(new Box(100, 100, 30, 30))
                //{
                //    Name = "Box 1",
                //    IsVisible = false
                //},

                //new ShapeModel(new Box(300, 100, 10, 10))
                //{
                //    Name = "Box 2",
                //    ScaleX = 3,
                //    ScaleY = 3,
                //    IsVisible = false
                //},

                new Shape3DModel(new Cube(0,0,100, 20,20,20))
                {
                    Name = "Hallo",
                    IsVisible = false
                },

                new Shape3DModel(new Cube(-100,0,100, 20,20,20))
                {
                    Name = "Hallo",
                    IsVisible = false
                }
            };

            Drawables.CollectionChanged += (s, e) =>
            {
                RaisePropertyChanged(nameof(PointsThroughCamera));

                foreach (var item in e.NewItems.OfType<Shape3DModel>())
                {
                    item.PropertyChanged += (s1, e1) =>
                    {
                        RaisePropertyChanged(nameof(PointsThroughCamera));
                    };
                }
            };

            foreach (var item in Drawables.OfType<Shape3DModel>())
            {
                item.PropertyChanged += (s, e) =>
                {
                    RaisePropertyChanged(nameof(PointsThroughCamera));
                };
            }

            //ABox = new Box2Model(100, 100, 30, 30);
            //ABox.Box.Rotation = 0;

            //Task.Factory.StartNew(async () =>
            //{
            //    while(true)
            //    {
            //        await Task.Delay(1);
            //        ABox.Box.Rotation++;

            //        ABox.Box.Translate.X = (ABox.Box.Translate.X + 1) % 150;
            //        //ABox.Box.Translate.Y = (ABox.Box.Translate.Y + 1) % 150;

            //        RaisePropertyChanged(nameof(ABox));
            //    }
            //});
            //ABox.Box.Width = 20;
            //ABox.Box.Height = 20;
            //ABox.Box.RotateX = 90;

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}
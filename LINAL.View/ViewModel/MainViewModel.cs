using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LINAL.Types;
using LINAL.Types.Shapes;
using LINAL.View.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        public ICommand LineMouseOverCommand => new RelayCommand<string>(OnLineMouseOver);
        public ICommand AddVectorCommand => new RelayCommand(AddVector);
        public ICommand AddBoxCommand => new RelayCommand(AddBox);
        public ICommand AddTriangleCommand => new RelayCommand(AddTriangle);
        public ICommand RemoveVectorCommand => new RelayCommand<string>(RemoveVector);
        public ICommand RemoveBoxCommand => new RelayCommand<string>(RemoveBox);

        public ShapeModel ABox { get; set; }

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
                new Vector2Model()
                {
                    Name = "Vector 1",
                    Origin = new Point3(10,10,0),
                    Vector = new Vector3(20,20,0)
                },

                new Vector2Model()
                {
                    Name = "Vector 2",
                    Origin = new Point3(40,10,0),
                    Vector = new Vector3(20,20,0)
                },

                new ShapeModel(new Box(100, 100, 30, 30))
                {
                    Name = "Box 1"
                },

                new ShapeModel(new Box(300, 100, 10, 10))
                {
                    Name = "Box 2",
                    ScaleX = 3,
                    ScaleY = 3
                },
            };

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
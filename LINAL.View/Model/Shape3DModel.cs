using LINAL.Types.Points;
using LINAL.Types.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LINAL.View.Model
{
    public class Shape3DModel : Drawable
    {
        public Shape3D Shape { get; set; }

        public Shape3DModel(Shape3D shape) : base("shape3d")
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

        public double LocationZ
        {
            get => Shape.Translate.Z;
            set
            {
                Shape.Translate.Z = value;
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

        public double Depth
        {
            get => Shape.Size.Z;
            set
            {
                Shape.Size.Z = value;
                OnPropertyChanged();
                Changed();
            }
        }

        void Changed()
        {
            OnPropertyChanged(nameof(Points));
        }

        public IEnumerable<Point4> Points => Shape.ToList();
        public PointCollection PointCollection => new PointCollection(Points.Select(p => new System.Windows.Point(p.X, p.Y)));
    }
}

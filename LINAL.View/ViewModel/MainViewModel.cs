using GalaSoft.MvvmLight;
using LINAL.Types;
using LINAL.View.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
        public ObservableCollection<Line2d> Lines { get; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Lines = new ObservableCollection<Line2d>()
            {
                new Line2d()
                {
                    Name = "Vector 1",
                    Origin = new Point3(10,10,0),
                    Vector = new Vector3(20,20,0)
                },
                new Line2d()
                {
                    Name = "Vector 2",
                    Origin = new Point3(40,10,0),
                    Vector = new Vector3(20,20,0)
                }
            };

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
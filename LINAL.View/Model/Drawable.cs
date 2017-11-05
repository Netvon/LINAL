using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LINAL.View.Model
{
    public abstract class Drawable : INotifyPropertyChanged
    {
        bool isVisible = true;
        string name;
        bool showLabel;

        public bool IsVisible
        {
            get { return isVisible; }

            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public string Category { get; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public bool ShowLabel
        {
            get => showLabel;

            set
            {
                if (showLabel != value)
                {
                    showLabel = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected Drawable(string category)
        {
            Category = category ?? throw new ArgumentNullException(nameof(category));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand MouseOverCommand => new RelayCommand(OnMouseOver);

        void OnMouseOver()
        {
            ShowLabel = !ShowLabel;
        }
    }
}

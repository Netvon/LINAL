using LINAL.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LINAL.View.DataTemplateSelectors
{
    public class DrawableItemEditorDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Drawable drawable && container is FrameworkElement element)
            {
                return element.FindResource($"{drawable.Category}ItemEditor") as DataTemplate;
            }

            return null;
        }
    }
}

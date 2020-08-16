using BellIntegratorTestTask.Core.Models;
using System.Windows;
using System.Windows.Controls;

namespace BellIntegratorTestTask.Resources
{
    public class EntityListDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is Product)
            {
                //Task taskitem = item as Task;

                //if (taskitem.Priority == 1)
                //    return
                //        element.FindResource("importantTaskTemplate") as DataTemplate;
                //else
                //    return
                //        element.FindResource("myTaskTemplate") as DataTemplate;
                return element.FindResource("IgiTemplate") as DataTemplate;
            }

            return null;
        }
    }
}

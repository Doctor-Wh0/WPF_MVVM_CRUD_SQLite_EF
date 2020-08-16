using BellIntegratorTestTask.Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BellIntegratorTestTask.ViewModels
{
    class EntityTableSelectionViewModel : IPageViewModel
    {
        public void RestoreTab(object obj)
        {
            Console.WriteLine("AAAAAAAAAAAAAAAA");
        }

        private ICommand _goToTablePage;
        public ICommand GoToTablePage
        {
            get
            {
                return _goToTablePage ?? (_goToTablePage = new RelayCommand(x =>
                {
                    var s = x as string;
                    BellIntegratorTestTask.Mediator.Mediator.Notify("GoTo1Screen", s);
                }));
            }
        }
    }
}

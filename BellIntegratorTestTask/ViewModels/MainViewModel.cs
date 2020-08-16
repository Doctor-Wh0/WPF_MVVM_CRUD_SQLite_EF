using BellIntegratorTestTask.Core.Models;
using BellIntegratorTestTask.Mediator;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BellIntegratorTestTask.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel/*BaseEntityViewModel*/ _currentPageViewModel;
        private List<IPageViewModel/*BaseEntityViewModel*/> _pageViewModels;

        public List<IPageViewModel/*BaseEntityViewModel*/> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel/*BaseEntityViewModel*/>();

                return _pageViewModels;
            }
        }

        public IPageViewModel/*BaseEntityViewModel*/ CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        private void ChangeViewModel(IPageViewModel/*BaseEntityViewModel*/ viewModel, object obj)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);

            CurrentPageViewModel.RestoreTab(obj);
        }

        private void OnGo1Screen(object obj)
        {
            //ChangeViewModel(PageViewModels[0], obj);
            switch (obj as string)
            {
                case "Products":
                    ChangeViewModel(PageViewModels[1], obj);
                    break;
                case "Customers":
                    ChangeViewModel(PageViewModels[4], obj);
                    break;
                case "Employees":
                    ChangeViewModel(PageViewModels[2], obj);
                    break;
            }

        }

        private void OnGo2Screen(object obj)
        {
            ChangeViewModel(PageViewModels[0], obj);
        }

        private void OnUpdateProducts(object obj)
        {
            PageViewModels[1].RestoreTab(obj);

        }
        private void OnUpdateEmployees(object obj)
        {
            PageViewModels[2].RestoreTab(obj);
        }

        public MainWindowViewModel()
        {
            
            // Add available pages and set page
            PageViewModels.Add(new EntityTableSelectionViewModel());
            PageViewModels.Add(new ProductListViewModel());
            PageViewModels.Add(new EmployeeListViewModel());

            CurrentPageViewModel = PageViewModels[0];

            BellIntegratorTestTask.Mediator.Mediator.Subscribe("GoTo1Screen", OnGo1Screen);
            BellIntegratorTestTask.Mediator.Mediator.Subscribe("GoTo2Screen", OnGo2Screen);
            BellIntegratorTestTask.Mediator.Mediator.Subscribe("UpdateProducts", OnUpdateProducts);
            BellIntegratorTestTask.Mediator.Mediator.Subscribe("UpdateEmployees", OnUpdateEmployees);
        }
    }
}

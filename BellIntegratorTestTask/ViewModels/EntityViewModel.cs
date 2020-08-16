using BellIntegratorTestTask.Core.Models;
using BellIntegratorTestTask.DAL;
using BellIntegratorTestTask.DAL.Interfaces;
using BellIntegratorTestTask.Mediator;
using BellIntegratorTestTask.Views;
using CommonServiceLocator;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BellIntegratorTestTask.ViewModels
{
    public class EntityViewModel<T> : BaseViewModel, IPageViewModel /*BaseEntityViewModel*/ where T : class, new()
    {
        private ObservableCollection<T> _items;
        public ObservableCollection<T> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }
        T s = new T();

        private T _selectedItem;
        public T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ICommand _goToMenu;
        private ICommand _insertCommand;
        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        public ICommand GoToMenu
        {
            get
            {
                return _goToMenu ?? (_goToMenu = new RelayCommand(x =>
                {
                    BellIntegratorTestTask.Mediator.Mediator.Notify("GoTo2Screen");
                }));
            }
        }
        public ICommand InsertCommand
        {
            get
            {
                return _insertCommand ?? (_insertCommand = new RelayCommand(x =>
                {
                    if(s is Product)
                    {
                        ProductInsertUpdateView insertUpdateWindow = new ProductInsertUpdateView();
                        ProductInsertUpdateViewModel context = new ProductInsertUpdateViewModel();
                        insertUpdateWindow.DataContext = context;
                        insertUpdateWindow.Show();
                    }
                    else
                    {
                        EmployeeInsertUpdateView insertUpdateWindow = new EmployeeInsertUpdateView();
                        EmployeeInsertUpdateViewModel context = new EmployeeInsertUpdateViewModel();
                        insertUpdateWindow.DataContext = context;
                        insertUpdateWindow.Show();
                    }
                    Console.WriteLine("Insert command");
                }));
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(x =>
                {
                    if (s is Product)
                    {
                        ProductInsertUpdateView insertUpdateWindow = new ProductInsertUpdateView();
                        ProductInsertUpdateViewModel context = new ProductInsertUpdateViewModel(SelectedItem as Product);
                        insertUpdateWindow.DataContext = context;
                        insertUpdateWindow.Show();
                    }
                    else
                    {
                        EmployeeInsertUpdateView insertUpdateWindow = new EmployeeInsertUpdateView();
                        EmployeeInsertUpdateViewModel context = new EmployeeInsertUpdateViewModel(SelectedItem as Employee);
                        insertUpdateWindow.DataContext = context;
                        insertUpdateWindow.Show();
                    }
                    

                    Console.WriteLine("Update command");
                }));
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(x =>
                {
                    _service.Delete(SelectedItem);
                    RestoreTab(null);
                    Console.WriteLine("Delete command");
                }));
            }
        }
        private IService<T> _service;
        public EntityViewModel() 
        {
            if (s is Product)
            {
                _service = (IService<T>)ServiceLocator.Current.GetInstance<ProductService>();
            }
            else
            {
                _service = (IService<T>)ServiceLocator.Current.GetInstance<EmployeeService>();
            }

            Items = new ObservableCollection<T>(_service.List());
        }

        public void RestoreTab(object obj)
        {
            //Console.WriteLine("EntityViewModel "+obj as string );
            Items = new ObservableCollection<T>(_service.List());
        }


    }
}

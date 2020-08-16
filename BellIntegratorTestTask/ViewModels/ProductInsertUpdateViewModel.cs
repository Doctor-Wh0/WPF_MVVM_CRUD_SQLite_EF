using BellIntegratorTestTask.Core.Models;
using BellIntegratorTestTask.DAL;
using BellIntegratorTestTask.LogService;
using BellIntegratorTestTask.Mediator;
using BellIntegratorTestTask.Views;
using CommonServiceLocator;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BellIntegratorTestTask.ViewModels
{
    public class ProductInsertUpdateViewModel : INotifyPropertyChanged
    {
        ProductService _service;
        LoggerService  _logger;
        public ProductInsertUpdateViewModel(Product product) : this()
        {
            
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Articul = product.Articul;
            Manufacturer = product.Manufacturer;
            Quantity = product.Quantity;
            Unity = product.Unity;
        }

        public ProductInsertUpdateViewModel()
        {
            _service = ServiceLocator.Current.GetInstance<ProductService>();
            _logger = ServiceLocator.Current.GetInstance<LoggerService>();
        }

        private int? _id;
        private string _name;
        private string _description;
        private double? _price;
        private string _articul;
        private string _manufacturer;
        private double? _quantity;
        private string _unity;
        private string _warninLabel;

        #region Properties

        public string WarningLabel
        {
            get { return _warninLabel; }
            set { _warninLabel = value; OnPropertyChanged("WarningLabel"); }
        }

        public int? Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("Description"); }
        }
        public double? Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged("Price"); }
        }
        public string Articul
        {
            get { return _articul; }
            set { _articul = value; OnPropertyChanged("Articul"); }
        }
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; OnPropertyChanged("Manufacturer"); }
        }
        // сколько
        public double? Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged("Quantity"); }
        }
        //Мера измерения
        public string Unity
        {
            get { return _unity; }
            set { _unity = value; OnPropertyChanged("Unity"); }
        }

        #endregion

        private ICommand _cancelCommand;
        private ICommand _updateCommand;
        private ICommand _insertCommand;

        public ICommand InsertCommand
        {
            get
            {
                return _insertCommand ?? (_insertCommand = new RelayCommand(x =>
                {
                    if (CheckFields())
                    {
                        var product = new Product();
                        product.Manufacturer = Manufacturer;
                        product.Name = Name;
                        product.Price = (double)Price;
                        product.Articul = Articul;
                        product.Quantity = (double)Quantity;
                        product.Unity = Unity;
                        product.Description = Description;
                        _service.Insert(product);
                        BellIntegratorTestTask.Mediator.Mediator.Notify("UpdateProducts");
                        var s = x as Window;
                        s.Close();
                    }
                }));
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(x =>
                {
                    var s = x as Window;
                    s.Close();

                }));
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(x =>
                {
                    if (!Id.HasValue) { InsertCommand.Execute(x);  return; }
                    var product = _service.Find((int)Id);
                    if (CheckFields())
                    {
                        product.Manufacturer = Manufacturer;
                        product.Name = Name;
                        product.Price = (double)Price;
                        product.Articul = Articul;
                        product.Quantity = (double)Quantity;
                        product.Unity = Unity;
                        product.Description = Description;
                        _service.Update(product);
                        
                        BellIntegratorTestTask.Mediator.Mediator.Notify("UpdateProducts");
                        var s = x as Window;
                        s.Close();

                    }

                }));
            }
        }

        private bool CheckFields()
        {
            bool IsChecked = true;
            String fields = "";

            if (String.IsNullOrWhiteSpace(Name))
            {
                fields += "'Название'";
            }
            if (String.IsNullOrWhiteSpace(Unity))
            {
                fields += "'Единица изм.'";
            }
            if (!Price.HasValue)
            {
                fields += "'Цена'";
            }
            if (!Quantity.HasValue)
            {
                fields += "'Количество'";
            }
            if (fields.Length > 0)
            {
                IsChecked = false;
                WarningLabel = "Заполните следующие поля: " + fields;
                _logger.Warn(WarningLabel);
            }
            return IsChecked;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

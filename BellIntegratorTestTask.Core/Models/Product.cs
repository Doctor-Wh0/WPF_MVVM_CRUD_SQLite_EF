using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace BellIntegratorTestTask.Core.Models
{
    [Table("Products")]
    public class Product : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _description;
        private double _price;
        private string _articul;
        private string _manufacturer;
        private double _quantity;
        private string _unity;

        public int Id
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
        public double Price
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
        public double Quantity
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


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
    }
}

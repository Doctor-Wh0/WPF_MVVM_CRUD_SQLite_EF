using BellIntegratorTestTask.Core.Models;
using BellIntegratorTestTask.DAL;
using BellIntegratorTestTask.LogService;
using BellIntegratorTestTask.Mediator;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace BellIntegratorTestTask.ViewModels
{
    class EmployeeInsertUpdateViewModel : INotifyPropertyChanged
    {
        EmployeeService _service;
        LoggerService _logger;

        public EmployeeInsertUpdateViewModel(Employee empl) : this()
        {
            EmployeeId = empl.EmployeeId;
            Name = empl.Name;
            SecondName = empl.SecondName;
            SurName = empl.SurName;
            Age = empl.Age;
            Phone = empl.Phone;
            Post = empl.Post;
            Salary = empl.Salary;
            Seniority = empl.Seniority;
        }
        public EmployeeInsertUpdateViewModel()
        {
            _service = ServiceLocator.Current.GetInstance<EmployeeService>();
            _logger = ServiceLocator.Current.GetInstance<LoggerService>();
        }


        int? _employeeId;
        string _name;
        string _secondName;
        string _surName;
        byte? _age;
        string _phone;
        string _post;
        double? _salary;
        double? _seniority;
        private string _warninLabel;

        #region Properties
        public string WarningLabel
        {
            get { return _warninLabel; }
            set { _warninLabel = value; OnPropertyChanged("WarningLabel"); }
        }
        public int? EmployeeId { 
            get{ return _employeeId; }
            set{ _employeeId = value; OnPropertyChanged("EmployeeId"); }
        }
        public string Name { 
            get{ return _name; }
            set { _name = value; OnPropertyChanged("Name"); } 
        }
        public string SecondName { 
            get{ return _secondName; }
            set { _secondName = value; OnPropertyChanged("SecondName"); }
        }
        public string SurName { 
            get{ return _surName; }
            set { _surName = value; OnPropertyChanged("SurName"); }
        }
        public byte? Age { 
            get{ return _age; }
            set { _age = value; OnPropertyChanged("Age"); }
        }
        public string Phone { 
            get{ return _phone; }
            set { _phone = value; OnPropertyChanged("Phone"); }
        }
        public string Post { 
            get{ return _post; }
            set { _post = value; OnPropertyChanged("Post"); }
        }
        public double? Salary { 
            get{ return _salary; }
            set { _salary = value; OnPropertyChanged("Salary"); }
        }
        public double? Seniority { 
            get{ return _seniority; }
            set { _seniority = value; OnPropertyChanged("Seniority"); }
        }

        #endregion

        private ICommand _cancellCommand;
        private ICommand _updateCommand;
        private ICommand _insertCommand;

        #region Commands
        public ICommand InsertCommand
        {
            get
            {
                return _insertCommand ?? (_insertCommand = new RelayCommand(x =>
                {
                    
                    if (CheckFields())
                    {
                        Employee employee = new Employee();
                        employee.Name = Name;
                        employee.SecondName = SecondName;
                        employee.SurName = SurName;
                        employee.Age = (byte)Age;
                        employee.Phone = Phone;
                        employee.Post = Post;
                        employee.Seniority = (double)Seniority;
                        employee.Salary = (double)Salary;
                        _service.Insert(employee);
                        BellIntegratorTestTask.Mediator.Mediator.Notify("UpdateEmployees");
                        var s = x as Window;
                        s.Close();
                    }
                }));
            }
        }
        public ICommand CancellCommand
        {
            get
            {
                return _cancellCommand ?? (_cancellCommand = new RelayCommand(x =>
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
                    if (!EmployeeId.HasValue) { InsertCommand.Execute(x); return; }
                    var employee = _service.Find(EmployeeId);
                    if (CheckFields())
                    {
                        employee.Name = Name;
                        employee.SecondName = SecondName;
                        employee.SurName = SurName;
                        employee.Age = (byte)Age;
                        employee.Phone = Phone;
                        employee.Post = Post;
                        employee.Seniority = (double)Seniority;
                        employee.Salary = (double)Salary;
                        _service.Update(employee);
                        BellIntegratorTestTask.Mediator.Mediator.Notify("UpdateEmployees");
                        var s = x as Window;
                        s.Close();
                    }
                    
                    
                }));
            }
        }
        #endregion


        private bool CheckFields()
        {
            bool IsChecked = true;
            String fields = "";
            if (String.IsNullOrWhiteSpace(Name))
            {
                fields += "'Имя'";
            }
            if (String.IsNullOrWhiteSpace(SecondName))
            {
                fields += "'Отчество'";
            }
            if (String.IsNullOrWhiteSpace(SurName))
            {
                fields += "'Фамилия'";
            }
            if (String.IsNullOrWhiteSpace(Post))
            {
                fields += "'Должность'";
            }
            if (String.IsNullOrWhiteSpace(Phone))
            {
                fields += "'Телефон'";
            }
            if (!Age.HasValue)
            {
                fields += "Заполните поле  'Возраст'";
            }
            if (!Seniority.HasValue)
            {
                fields += "Заполните поле  'Стаж'";
            }
            if (!Salary.HasValue)
            {
                fields += "Заполните поле  'Зарплатка'";
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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace BellIntegratorTestTask.Core.Models
{
    [Table("Employees")]
    public class Employee : INotifyPropertyChanged
    {
        private int _employeeId;
        private string _name;
        private string _secondName;
        private string _surName;
        private byte _age;
        private string _phone;
        private double _salary;
        private string _post;
        private double _seniority;


        public int EmployeeId { get { return _employeeId; } set { _employeeId = value; OnPropertyChanged("EmployeeId"); } }
        public string Name {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; OnPropertyChanged("SecondName"); }
        }
        public string SurName
        {
            get { return _surName; }
            set { _surName = value; OnPropertyChanged("SurName"); }
        }
        public byte Age { get { return _age; } set { _age = value; OnPropertyChanged("Age"); } }
        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged("Phone"); } }
        public string Post { get { return _post; } set { _post = value; OnPropertyChanged("Post"); } }
        public double Salary { get { return _salary; } set { _salary = value; OnPropertyChanged("Salary"); } }
        public double Seniority { get { return _seniority; } set { _seniority = value; OnPropertyChanged("Seniority"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}

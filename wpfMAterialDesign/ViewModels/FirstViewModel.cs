using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfMAterialDesign.Models;

namespace wpfMAterialDesign.ViewModels
{
    public class FirstViewModel : Conductor<object>
    {
        private string _firstname = "Genesis Ivan";
        private string _lastname;
        private BindableCollection<PersonModel> _peope = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        public FirstViewModel()
        {
            People.Add(new PersonModel { Firstname = "Genesis Ivan", Lastname = "Aquino" });
            People.Add(new PersonModel { Firstname = "Jhon Mayson", Lastname = "Labuntog" });
            People.Add(new PersonModel { Firstname = "John Xavier", Lastname = "Buenaventura" });
            People.Add(new PersonModel { Firstname = "John Benson", Lastname = "Leabres" });
        }


        public string Firstname
        {
            get {
                return _firstname;
            }
            set {
                _firstname = value;
                NotifyOfPropertyChange(() => Firstname);
                NotifyOfPropertyChange(() => Fullname);
            }
        }
        public String Lastname
        {
            get { return _lastname; }
            set {
                _lastname = value;
                NotifyOfPropertyChange(() => Fullname);
            }
        }
        public String Fullname
        {
            get { return $"{ Firstname } { Lastname }"; }
        }
        public BindableCollection<PersonModel> People
        {
            get { return _peope; }
            set { _peope = value; }
        }
        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson); 
            }
        }
        public bool CanClearText(string firstName, string lastName)
        {
            if(String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ClearText(string firstName, string lastName)
        {
            Firstname = "";
            Lastname = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }
        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }

    }

}

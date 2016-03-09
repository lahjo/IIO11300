using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitus6_Binding
{
    public class HockeyPlayer : INotifyPropertyChanged {
        private string name, number;
        public string Name {
            set { name = value; Notify("Name"); Notify("NameAndNumber"); }
            get { return name; }
        }
        public string Number {
            set { number = value; Notify("Number"); Notify("NameAndNumber"); }
            get { return number; }
        }
        public string NameAndNumber {
            get { return name + " #" + number; }
        }

        public HockeyPlayer() { }
        public HockeyPlayer(string name, string number) {
            this.name = name;
            this.number = number;
        }

        // Method
        public override string ToString()
        {
            return name + " #" + number;
        }

        // INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    public class HockeyTeam
    {
        #region PROPERTIES
        // Huom public field ei keplaa WPF DataBinding:ssa, pitää olla Property
        public string Name { get; set; }
        public string City { get; set; }
        #endregion

        #region CONSTRUCTOR
        public HockeyTeam() {
            Name = "";
            City = "unknown";
        }

        public HockeyTeam(string name, string city) {
            this.Name = name;
            this.City = city;
        }
        #endregion

        public override string ToString()
        {
            return Name + "@" + City; 
        }
    }

    public class HockeyLeague {
        // Pertustetaan SM-Liiga, sisältää x kpl joukkueita
        List<HockeyTeam> teams = new List<HockeyTeam>();

        public HockeyLeague()
        {
            teams.Add(new HockeyTeam("HIFK", "HELSINKI"));
            teams.Add(new HockeyTeam("JYP", "Jyväskylä"));
            teams.Add(new HockeyTeam("Kalpa", "Kuopio"));
            teams.Add(new HockeyTeam("Sport", "Vaasa"));
        }

        // Metodi joka palauttaa Liigan joukkueet
        public List<HockeyTeam> GetTeams() {
            return teams;
        }
    }
}

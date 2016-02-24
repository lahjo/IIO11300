using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitus6_Binding
{
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperHowToData.POCOs
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int numplayers { get; set; }
        public DateTime RetrievedOn { get; set; }
        public override string ToString()
        {
            return this.TeamName ?? "";
        }

        public Team(int TeamID, string TeamName, DateTime RetrievedOn)
        {
            this.TeamID = TeamID;
            this.TeamName = TeamName;
            this.RetrievedOn = RetrievedOn;
        }
       
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperHowToData.POCOs
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int TeamID { get; set; }
        public override string ToString()
        {
            return this.PlayerName ?? "";
        }
    }
}

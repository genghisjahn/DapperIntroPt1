﻿using System;
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
        public override string ToString()
        {
            return  this.TeamName ?? "";
        }
    }
}

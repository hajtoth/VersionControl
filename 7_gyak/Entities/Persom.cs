﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_gyak.Entities
{
    public class Persom
    {
        public int BirthYear { get; set; }
        public Gender Gender { get; set; }
        public int NbrOfChildren { get; set; }
        public bool IsAlive { get; set; }

        public Person()
        {
            IsAlive = true;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest
{
    class BluePotion:Weapon
    {
        public static bool iksirCheck;
        public BluePotion(int iksirGucu)
        {
            this.iksirGucu = iksirGucu;
            this.hitPoint = 0; //iksirle damage verilmiyor
        }
    }
}

using Lift.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] queues =
            {
            new int[0], // G
            new int[0], // 1
            new int[]{4,3,5,6}, // 2
            new int[0], // 3
            new int[]{5}, // 4
            new int[]{6}, // 5
            new int[]{1,4,2 }, // 6
            };
            Building myBuilding = new Building(5, queues);
            myBuilding.Go();
        }
    }
}

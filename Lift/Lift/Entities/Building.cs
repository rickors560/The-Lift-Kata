using Lift.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lift.Entities
{
    public class Building
    {
        public Floor[] Floors { get; set; }

        public Lift Lift { get; set; }

        public Building(int liftCapacity, int[][] floorAndPeopleComposition)
        {
            Floors = floorAndPeopleComposition.Select((floorComposition, floorNumber) =>
            {
                var floor = new Floor(floorNumber, floorComposition);
                floor.ButtonPressedForCallingTheLift += this.LiftRequested;
                return floor;
            }).ToArray();

            Lift = new Lift(liftCapacity);

            Lift.LiftArriverAtAFloor += LiftArrivedAtAFloor;
        }

        public void LiftRequested(Direction direction, int floorNumberRequestedOn)
        {

        }

        public void LiftArrivedAtAFloor(int floorNumber)
        {
            var floor = this.Floors.Single(floor => floor.FloorNumber == floorNumber);
            floor.LiftHasArrived(this.Lift);
        }
    }
}

using Lift.Delegates;
using Lift.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lift.Entities
{
    public class Floor
    {
        public event ButtonPressedForCallingTheLiftOnAGivenFloor ButtonPressedForCallingTheLift;
        public int FloorNumber { get; set; }
        public List<Person> PeopleWaitingForLift { get; set; }
        public List<Person> PeopleBelongToTheFloor { get; set; }
        public Floor(int floorNumber, int[] peopleWaitingOnTheFloorToGo)
        {
            this.FloorNumber = floorNumber;
            this.PeopleWaitingForLift = peopleWaitingOnTheFloorToGo.Select((floorPersonWantToGo)=> {
                var person = new Person(this.FloorNumber, floorPersonWantToGo);
                person.ButtonPressed += this.ButtonPress;
                return person;
            }).ToList();
        }
        public void ButtonPress(Direction direction) {
            //Console.WriteLine("buttonPressed");
            this.ButtonPressedForCallingTheLift(direction, this.FloorNumber, this.PeopleWaitingForLift);
        }
    }
}

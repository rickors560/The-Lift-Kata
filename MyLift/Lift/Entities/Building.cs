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
            this.Floors = floorAndPeopleComposition.Select((floorComposition, floorNumber)=> {
                var floor = new Floor(floorNumber, floorComposition);
                floor.ButtonPressedForCallingTheLift += this.LiftRequested;
                return floor;
            }).ToArray();
            this.Lift = new Lift(liftCapacity, this.Floors.Length-1);
        }
        public void Go() {
            foreach (Floor floor in Floors) {
                //if (floor.PeopleWaitingForLift.Count() > 0)
                //{
                //    floor.PeopleWaitingForLift.First().PressButton();
                //}
                floor.PeopleWaitingForLift.ForEach(p =>
                {
                    while (p.WaitingStatus == WaitingStatus.Waiting)
                    {
                        p.PressButton();
                    }
                });
            }
            this.Lift.MoveToTop();
            this.Lift.MoveToGround();
            Console.WriteLine($"Stopped On:{this.Lift.CurrentFloor}");
        }
        public void LiftRequested(Direction direction, int floorNumberRequestedOn, List<Person> peopleWaiting) {

            Console.WriteLine($"Stopped On:{this.Lift.CurrentFloor}");
            this.Lift.LiftStart(direction, floorNumberRequestedOn);
            //this.Lift.CurrentFloor = floorNumberRequestedOn;
            peopleWaiting.ForEach(person=> {
                if (person.DestinationFloor > this.Lift.CurrentFloor)
                {
                    person.WaitingStatus = WaitingStatus.BoardedLift;
                    this.Lift.People.Add(person);
                }
                else if (person.DestinationFloor < this.Lift.CurrentFloor) {
                    person.WaitingStatus = WaitingStatus.BoardedLift;
                    this.Lift.People.Add(person);
                }
            });
        }
    }
}

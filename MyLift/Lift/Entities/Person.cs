using Lift.Delegates;
using Lift.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lift.Entities
{
    public class Person
    {
        public event ButtonPressedForCallingTheLift ButtonPressed;
        public int CurrentFloor { get; set; }
        public int DestinationFloor { get; set; }
        public WaitingStatus WaitingStatus { get; set; }
        public Direction DirectionToGoIn {
            get {
                return this.CurrentFloor > this.DestinationFloor ? Direction.Down : Direction.Up;
            }
        }
        public Person(int currentFloor, int destinationFloor)
        {
            this.CurrentFloor = currentFloor;
            this.DestinationFloor = destinationFloor;
            this.WaitingStatus = WaitingStatus.Waiting;
        }
        public void PressButton() {
           // Console.WriteLine("Button Pressed by person");
            this.ButtonPressed(this.DirectionToGoIn);
        }
    }
}

using Lift.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lift.Entities
{
    public class Lift
    {
        public int Capacity { get; set; }
        public List<Person> People { get; set; }
        public int CurrentFloor { get; set; }
        public int TopFloor { get;}
        public Lift(int capacity, int topFloor)
        {
            this.CurrentFloor = 0;
            this.Capacity = capacity;
            this.TopFloor = topFloor;
            this.People = new List<Person>();
        }
        public void MoveToTop() {
            if (this.People.Count > 0)
            {
                int maxFloorButtonPressed = this.People.Select(p => {
                    return p.DestinationFloor;
                }).ToArray().Max();
                //Console.WriteLine(maxFloorButtonPressed);
                while (this.CurrentFloor <= maxFloorButtonPressed || this.CurrentFloor <= this.TopFloor)
                {
                    this.CurrentFloor++;
                    List<Person> Newpeople = new List<Person>();
                    bool peopleReached = false;
                    this.People.ForEach(p =>
                    {
                        p.CurrentFloor = this.CurrentFloor;
                        if (p.DestinationFloor == this.CurrentFloor)
                        {
                            peopleReached = true;
                            Console.WriteLine($"{p.DestinationFloor} Reached");
                            p.WaitingStatus = WaitingStatus.Reached;
                        }
                        else
                        {
                            Newpeople.Add(p);
                        }
                    });
                    if (peopleReached) {
                        Console.WriteLine($"Stopped On:{this.CurrentFloor}");
                    }
                    this.People = Newpeople;
                }
            }
            else {
                this.MoveToGround();
            }
        }
        public void MoveToGround() {
            if (this.People.Count == 0)
            {
                this.CurrentFloor = 0;
            }
            else {
                while (this.CurrentFloor > 0)
                {
                    this.CurrentFloor--;
                    List<Person> Newpeople = new List<Person>();
                    bool peopleReached = false;
                    this.People.ForEach(p =>
                    {
                        p.CurrentFloor = this.CurrentFloor;
                        if (p.DestinationFloor == this.CurrentFloor)
                        {
                            peopleReached = true;
                            Console.WriteLine($"{p.DestinationFloor} Reached");
                            p.WaitingStatus = WaitingStatus.Reached;
                        }
                        else
                        {
                            Newpeople.Add(p);
                        }
                    });
                    if (peopleReached) {
                        Console.WriteLine($"Stopped On:{this.CurrentFloor}");
                    }
                    this.People = Newpeople;
                }
            }
        }
        private void MoveUp(int floorToGo) {
            while (floorToGo > this.CurrentFloor && this.CurrentFloor <= this.TopFloor) {
                this.CurrentFloor++;
                List<Person> Newpeople = new List<Person>();
                bool peopleReached = false;
                this.People.ForEach(p =>
                {
                    p.CurrentFloor = this.CurrentFloor;
                    if (p.DestinationFloor == this.CurrentFloor)
                    {
                        peopleReached = true;
                        Console.WriteLine($"{p.DestinationFloor} Reached");
                        p.WaitingStatus = WaitingStatus.Reached;
                    }
                    else {
                        Newpeople.Add(p);
                    }
                });
                if (peopleReached)
                {
                    Console.WriteLine($"Stopped On:{this.CurrentFloor}");
                }
                this.People = Newpeople;
                this.People = Newpeople;
            }
        }
        private void MoveDown(int floorToGo) {
            while (floorToGo < this.CurrentFloor && this.CurrentFloor > 0)
            {
                this.CurrentFloor--;
                List<Person> Newpeople = new List<Person>();
                bool peopleReached = false;
                this.People.ForEach(p =>
                {
                    p.CurrentFloor = this.CurrentFloor;
                    if (p.DestinationFloor == this.CurrentFloor)
                    {
                        peopleReached = true;
                        Console.WriteLine($"{p.DestinationFloor} Reached");
                        p.WaitingStatus = WaitingStatus.Reached;
                    }
                    else
                    {
                        Newpeople.Add(p);
                    }
                });
                if (peopleReached)
                {
                    Console.WriteLine($"Stopped On:{this.CurrentFloor}");
                }
                this.People = Newpeople;
                this.People = Newpeople;
            }
        }
        public void LiftStart(Direction direction, int floorOnWhichRequested) {
            if (direction == Direction.Up)
            {
                this.MoveUp(floorOnWhichRequested);
            }
            else if (direction == Direction.Down)
            {
                this.MoveDown(floorOnWhichRequested);
            }
        }
    }
}

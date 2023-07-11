using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSimulator
{
    public class ControlElevator
    {
        
        public List<Elevator> elevators;
        

        public ControlElevator(int numberOfElevators)
        {
            elevators = new List<Elevator>();
            for (int i = 0; i < numberOfElevators; i++)
            {
                var elevator = new Elevator(0, 4); // Set floor and weight limit
                elevators.Add(elevator);
            }
        }

        public void CallElevator(int floor)
        {
            var nearestElevator = FindNearestAvailableElevator(floor);
            nearestElevator.MoveToFloor(floor);
        }

        private Elevator FindNearestAvailableElevator(int floor)
        {
            return elevators.OrderBy(e => Math.Abs(e.CurrentFloor - floor)).FirstOrDefault(e => !e.IsMoving && !e.IsFull);
        }

        public void SetPeopleWaitingOnFloor(int floor, int numberOfPeople)
        {
            //Setting number of people waiting on a floor
            Console.WriteLine($"{numberOfPeople} person/people waiting on floor {floor}.");
        }

        public void UpdateElevators()
        {
            foreach (var elevator in elevators)
            {
                if (elevator.IsMoving)
                {
                    if (elevator.CurrentFloor < elevator.DestinationFloor)
                    {
                        elevator.CurrentFloor++;
                    }
                    else if (elevator.CurrentFloor > elevator.DestinationFloor)
                    {
                        elevator.CurrentFloor--;
                    }
                    else
                    {
                        elevator.StopMoving();
                        elevator.OpenDoor();
                        elevator.CloseDoor();
                    }
                }
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine("Elevator Status:");
            foreach (var elevator in elevators)
            {
                string status = $"Floor: {elevator.CurrentFloor}, Moving: {elevator.IsMoving}, Direction: {(elevator.CurrentFloor < elevator.DestinationFloor ? "Up" : "Down")}";
                Console.WriteLine(status);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorSimulator
{
    public class Elevator
    {
        public int CurrentFloor { get; internal set; }
        public bool IsMoving { get; internal set; }
        public int DestinationFloor { get; internal set; }
        public int WeightLimit { get; internal set; }
        public int CurrentWeight { get; internal set; }
        public bool IsFull => CurrentWeight >= WeightLimit;

        public Elevator(int currentFloor, int weightLimit)
        {
            CurrentFloor = currentFloor;
            WeightLimit = weightLimit;
        }

        public void MoveToFloor(int destinationFloor)
        {
            DestinationFloor = destinationFloor;
            IsMoving = true;
            Console.WriteLine($"Elevator moving from floor {CurrentFloor} to floor {DestinationFloor}.");
        }

        public void StopMoving()
        {
            IsMoving = false;
            Console.WriteLine($"Elevator stopped at floor {CurrentFloor}.");
        }

        public void OpenDoor()
        {
            Console.WriteLine($"Elevator door opened at floor {CurrentFloor}.");
        }

        public void CloseDoor()
        {
            Console.WriteLine($"Elevator door closed at floor {CurrentFloor}.");
        }

        public void AddWeight(int weight)
        {
            CurrentWeight += weight;
        }

        public void RemoveWeight(int weight)
        {
            CurrentWeight -= weight;
        }
    }
}

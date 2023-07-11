using System;

namespace ElevatorSimulator
{
    class Program
    {
       public static void Main(string[] args)
        {
            // Create elevator controller with 3 elevators
            var controller = new ControlElevator(3);

            // Set number of people waiting on different floors
            controller.SetPeopleWaitingOnFloor(1, 4);
            controller.SetPeopleWaitingOnFloor(2, 3);
            controller.SetPeopleWaitingOnFloor(3, 1);

            // Elevator calls
            controller.CallElevator(2);
            controller.CallElevator(4);

            // Update elevator positions
            controller.UpdateElevators();

            // Show status
            controller.ShowStatus();

            Console.ReadLine();
        }

    }
}

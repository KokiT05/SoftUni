namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            string employeeId = "123098";
            Employee worker = new Employee(employeeId);
            worker.Work(8);
            worker.Sleep();

            string robotId = "Id131512";
            int capacity = 21;
            Robot robot = new Robot(robotId, capacity);
            robot.Recharge();
            robot.Work(8);
            Console.WriteLine(robot.CurrentPower);
            robot.Recharge();
            Console.WriteLine(robot.CurrentPower);

        }
    }
}

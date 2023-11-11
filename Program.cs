using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUT5_question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalesDataProcessor processor = new SalesDataProcessor();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Sales Data Processing Menu:");
                Console.WriteLine("1. Enter Sales Data");
                Console.WriteLine("2. Display Average Sales per Department");
                Console.WriteLine("3. Display Average Sales per Month");
                Console.WriteLine("4. Display Department with Highest Sales per Month");
                Console.WriteLine("5. Display Month with Highest Sales per Department");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        processor.PopulateArray();
                        break;
                    case 2:
                        processor.DisplayAverageSalesPerDepartment();
                        break;
                    case 3:
                        processor.DisplayAverageSalesPerMonth();
                        break;
                    case 4:
                        processor.DisplayHighestSalesPerDepartment();
                        break;
                    case 5:
                        processor.DisplayHighestSalesPerMonth();
                        break;
                    case 6:
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }

    class SalesDataProcessor
    {
        private int[,] sales = new int[4, 3]; // 4 departments, 3 months

        public void PopulateArray()
        {
            for (int dept = 0; dept < 4; dept++)
            {
                for (int month = 0; month < 3; month++)
                {
                    Console.Write($"Enter sales for department {dept + 1}, month {month + 1}: ");
                    sales[dept, month] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void DisplayAverageSalesPerDepartment()
        {
            Console.WriteLine("Average Sales per Department:");
            for (int dept = 0; dept < 4; dept++)
            {
                int sum = 0;
                for (int month = 0; month < 3; month++)
                {
                    sum += sales[dept, month];
                }
                double average = (double)sum / 3;
                Console.WriteLine($"Department {dept + 1}: {average:F2}");
            }
            Console.WriteLine();
        }

        public void DisplayAverageSalesPerMonth()
        {
            Console.WriteLine("Average Sales per Month:");
            for (int month = 0; month < 3; month++)
            {
                int sum = 0;
                int count = 0;
                for (int dept = 0; dept < 4; dept++)
                {
                    if (sales[dept, month] > 0)
                    {
                        sum += sales[dept, month];
                        count++;
                    }
                }
                if (count > 0)
                {
                    double average = (double)sum / count;
                    Console.WriteLine($"Month {month + 1}: {average:F2}");
                }
            }
            Console.WriteLine();
        }

        public void DisplayHighestSalesPerDepartment()
        {
            Console.WriteLine("Department with Highest Sales for Each Month:");
            for (int month = 0; month < 3; month++)
            {
                int maxSales = 0;
                int deptWithMaxSales = -1;
                for (int dept = 0; dept < 4; dept++)
                {
                    if (sales[dept, month] > maxSales)
                    {
                        maxSales = sales[dept, month];
                        deptWithMaxSales = dept;
                    }
                }
                if (deptWithMaxSales >= 0)
                {
                    Console.WriteLine($"Month {month + 1}: Department {deptWithMaxSales + 1}");
                }
            }
            Console.WriteLine();
        }

        public void DisplayHighestSalesPerMonth()
        {
            Console.WriteLine("Month with Highest Sales for Each Department:");
            for (int dept = 0; dept < 4; dept++)
            {
                int maxSales = 0;
                int monthWithMaxSales = -1;
                for (int month = 0; month < 3; month++)
                {
                    if (sales[dept, month] > maxSales)
                    {
                        maxSales = sales[dept, month];
                        monthWithMaxSales = month;
                    }
                }
                if (monthWithMaxSales >= 0)
                {
                    Console.WriteLine($"Department {dept + 1}: Month {monthWithMaxSales + 1}");
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }
     
    }
}

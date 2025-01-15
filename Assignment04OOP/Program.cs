using System;

namespace Assignment04OOP
{
    #region Q1: Overloaded Add Method in Calculator Class
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }
    }
    #endregion

    #region Q2: Rectangle Class with Multiple Constructors
    class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle()
        {
            Width = 0;
            Height = 0;
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Rectangle(int size)
        {
            Width = size;
            Height = size;
        }
    }
    #endregion

    #region Q3: Complex Number Class with Operator Overloading
    class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }
    }
    #endregion

    #region Q4: Employee and Manager Classes with Method Overriding
    class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Employee is working.");
        }
    }

    class Manager : Employee
    {
        public override void Work()
        {
            base.Work();
            Console.WriteLine("Manager is managing.");
        }
    }
    #endregion

    #region Q5: BaseClass and Derived Classes with Method Hiding and Overriding
    class BaseClass
    {
        public virtual void DisplayMessage()
        {
            Console.WriteLine("Message from BaseClass.");
        }
    }

    class DerivedClass1 : BaseClass
    {
        public override void DisplayMessage()
        {
            Console.WriteLine("Message from DerivedClass1.");
        }
    }

    class DerivedClass2 : BaseClass
    {
        public new void DisplayMessage()
        {
            Console.WriteLine("Message from DerivedClass2.");
        }
    }
    #endregion

    #region Part 2: Duration Class with Overriding and Operator Overloading
    class Duration
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = totalSeconds % 60;
        }

        public override string ToString()
        {
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Duration d)
            {
                return Hours == d.Hours && Minutes == d.Minutes && Seconds == d.Seconds;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds +
                                d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
        }

        public static Duration operator ++(Duration d)
        {
            return new Duration(d.Hours, d.Minutes + 1, d.Seconds);
        }

        public static Duration operator --(Duration d)
        {
            return new Duration(d.Hours, d.Minutes - 1, d.Seconds);
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region Q1 Example
            Calculator calc = new Calculator();
            Console.WriteLine("Add(int, int): " + calc.Add(2, 3));
            Console.WriteLine("Add(int, int, int): " + calc.Add(2, 3, 4));
            Console.WriteLine("Add(double, double): " + calc.Add(2.5, 3.5));
            #endregion

            #region Q2 Example
            Rectangle rect1 = new Rectangle();
            Rectangle rect2 = new Rectangle(4, 5);
            Rectangle rect3 = new Rectangle(6);
            Console.WriteLine($"Rect1: Width={rect1.Width}, Height={rect1.Height}");
            Console.WriteLine($"Rect2: Width={rect2.Width}, Height={rect2.Height}");
            Console.WriteLine($"Rect3: Width={rect3.Width}, Height={rect3.Height}");
            #endregion

            #region Q3 Example
            ComplexNumber c1 = new ComplexNumber(2, 3);
            ComplexNumber c2 = new ComplexNumber(4, 5);
            Console.WriteLine("c1 + c2: " + (c1 + c2));
            Console.WriteLine("c1 - c2: " + (c1 - c2));
            #endregion

            #region Q4 Example
            Employee emp = new Employee();
            emp.Work();
            Manager mgr = new Manager();
            mgr.Work();
            #endregion

            #region Q5 Example
            BaseClass baseClass = new BaseClass();
            baseClass.DisplayMessage();

            DerivedClass1 derived1 = new DerivedClass1();
            derived1.DisplayMessage();

            DerivedClass2 derived2 = new DerivedClass2();
            derived2.DisplayMessage();
            #endregion

            #region Part 2 Duration Example
            Duration d1 = new Duration(1, 10, 15);
            Console.WriteLine(d1);

            Duration d2 = new Duration(3600);
            Console.WriteLine(d2);

            Duration d3 = new Duration(7800);
            Console.WriteLine(d3);

            Duration d4 = new Duration(666);
            Console.WriteLine(d4);

            Duration d5 = d1 + d2;
            Console.WriteLine("d1 + d2: " + d5);

            d3++;
            Console.WriteLine("d3 after ++: " + d3);
            #endregion
        }
    }
}

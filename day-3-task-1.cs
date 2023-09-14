using System;

public abstract class Shape
{
    public string Name { get; set; }
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Triangle : Shape
{
    public double BaseLength { get; set; }
    public double HeightLength { get; set; }

    public override double CalculateArea()
    {
        return 0.5 * BaseLength * HeightLength;
    }
}

public class Program
{
    public static void PrintShapeArea(Shape shape)
    {
        Console.WriteLine("Name: " + shape.Name);
        Console.WriteLine("Area: " + shape.CalculateArea());
    }

    public static void Main()
    {
        Circle circle = new Circle();
        circle.Name = "Circle";
        circle.Radius = 5.0;
        PrintShapeArea(circle);

        Rectangle rect = new Rectangle();
        rect.Name = "Rectangle";
        rect.Width = 5.0;
        rect.Height = 2.0;
        PrintShapeArea(rect);

        Triangle trig = new Triangle();
        trig.Name = "Triangle";
        trig.BaseLength = 5.0;
        trig.HeightLength = 3.0;
        PrintShapeArea(trig);
    }
}

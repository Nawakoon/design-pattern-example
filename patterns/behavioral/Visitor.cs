namespace Pattern.Visitor
{
    // visitor
    public interface ShapeMath
    {
        double Cal(Square square);
        double Cal(Circle circle);
    }

    // concrete visitor 1
    public class AreaCalculator : ShapeMath
    {
        public double Cal(Square square)
        {
            return square.Side * square.Side;
        }

        public double Cal(Circle circle)
        {
            return circle.Radius * circle.Radius * Math.PI;
        }
    }

    // concrete visitor 2
    public class PerimeterCalculator : ShapeMath
    {
        public double Cal(Square square)
        {
            return 4 * square.Side;
        }

        public double Cal(Circle circle)
        {
            return 2 * circle.Radius * Math.PI;
        }
    }

    public interface Shape
    {
        double Calculate(ShapeMath visitor);
    }

    public class Square : Shape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public double Calculate(ShapeMath visitor)
        {
            return visitor.Cal(this);
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Calculate(ShapeMath visitor)
        {
            return visitor.Cal(this);
        }
    }

    public class Visitor : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nVisitor example\n");

            Shape square = new Square(5);
            Shape circle = new Circle(7);

            ShapeMath areaCalculator = new AreaCalculator();
            ShapeMath perimeterCalculator = new PerimeterCalculator();

            double squareArea = square.Calculate(areaCalculator);
            double squarePerimeter = square.Calculate(perimeterCalculator);
            double circleArea = circle.Calculate(areaCalculator);
            double circlePerimeter = circle.Calculate(perimeterCalculator);

            Console.WriteLine("Square area: " + squareArea);
            Console.WriteLine("Square perimeter: " + squarePerimeter);
            Console.WriteLine("Circle area: " + circleArea);
            Console.WriteLine("Circle perimeter: " + circlePerimeter);
        }
    }
}
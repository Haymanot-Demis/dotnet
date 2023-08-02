public class ShapeHierarchy{
    public static void Main(string[] args){
        Shape circle = new Circle("Circle", 10);
        Shape rectangle = new Rectangle("Rectangle", 5, 10);
        Shape triangle = new Triangle("Triangle", 16, 10, 10);
        System.Console.WriteLine($"Area of {circle.Name} is {circle.CalculateArea():F2}" );
        System.Console.WriteLine($"Area of {rectangle.Name} is {rectangle.CalculateArea():F2}");
        System.Console.WriteLine($"Area of {triangle.Name} is {triangle.CalculateArea():F2}");
    }
}
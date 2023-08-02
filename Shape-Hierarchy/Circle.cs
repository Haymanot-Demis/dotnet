public class Circle: Shape{
    public double Radius {get; set;}

    public Circle(string name, double radius): base(name)
    {
        Radius = radius;
    }

    public override double CalculateArea(){
        return Math.PI * Math.Pow(Radius, 2);
    }
}
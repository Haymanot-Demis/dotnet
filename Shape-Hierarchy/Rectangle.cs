public class Rectangle : Shape{
    public double Length {get; set;}
    public double Width {get; set;}

    public Rectangle(string name, double length, double width): base(name)
    {
        Length = length;
        Width = width;
    }

    public override double CalculateArea(){
        return Length * Width;
    }
}
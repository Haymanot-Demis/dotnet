public class Triangle: Shape{
    public double Base {get; set;}
    public double Height {get; set;}
    public double Side1 {get; set;}

    public double Side2 {get; set;}
    public double Side3 {get; set;}

    public Triangle(string name, double _base, double height): base(name)
    {
        Base = _base;
        Height = height;
    }
    public Triangle(string name, double side1, double side2, double side3): base(name)
    {
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;        
    }

    public override double CalculateArea(){
        if (Base > 0  && Height > 0){
            return 0.5 * Base * Height;
        }

        double s = (Side1 + Side2 + Side3) / 2;
        return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
    }
}
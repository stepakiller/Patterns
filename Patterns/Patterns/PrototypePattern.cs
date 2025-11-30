namespace Patterns
{
    public interface IShape3D
    {
        IShape3D Clone();
        void DisplayInfo();
        void SetPosition(float x, float y, float z);
    }

    public abstract class Shape3D : IShape3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public string Color { get; set; }

        protected Shape3D(float x, float y, float z, string color)
        {
            X = x;
            Y = y;
            Z = z;
            Color = color;
        }

        public abstract IShape3D Clone();
        public abstract void DisplayInfo();

        public void SetPosition(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class Cube : Shape3D
    {
        public float Size { get; set; }

        public Cube(float x, float y, float z, string color, float size) : base(x, y, z, color) => Size = size;

        public override IShape3D Clone() => new Cube(X, Y, Z, Color, Size);

        public override void DisplayInfo() => Console.WriteLine($"Cube - Position: ({X}, {Y}, {Z}), Color: {Color}, Size: {Size}");
    }

    public class Sphere : Shape3D
    {
        public float Radius { get; set; }

        public Sphere(float x, float y, float z, string color, float radius) : base(x, y, z, color) => Radius = radius;

        public override IShape3D Clone() => new Sphere(X, Y, Z, Color, Radius);

        public override void DisplayInfo() => Console.WriteLine($"Sphere - Position: ({X}, {Y}, {Z}), Color: {Color}, Radius: {Radius}");
    }
}

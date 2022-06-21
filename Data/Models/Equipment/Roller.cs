namespace Data.Models.Equipment
{
    public class Roller
    {
        public double Diameter { get; set; }

        public double Width { get; set; }

        public override string ToString()
        {
            return $"Roller: Diameter: {Diameter:F2} mm; Width: {Width:F2} mm";
        }
    }
}

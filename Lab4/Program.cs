namespace Lab4
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    public class Line
    {
        public Point leftP, rightP;

        public Line() { leftP = new Point(); rightP = new Point(); }

        public Line(Point l, Point r) { leftP = l; rightP = r; }

        public (Point, Point) GetPoints()
        {
            return (leftP, rightP);
        }
    }

}
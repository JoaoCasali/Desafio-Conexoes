namespace DesafioBenner
{
    public class Element
    {
        public int Number { get; set; }
        public HashSet<int> Connections { get; set; }

        public Element(int number)
        {
            Number = number;
            Connections = new HashSet<int>();
        }
    }
}

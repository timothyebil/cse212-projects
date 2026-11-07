namespace week02
{
    public class Person
    {
        public string Name { get; set; }
        public int Turns { get; set; }
        
        // Alias property so PriorityQueue can compile cleanly without modifying test structures
        public int Priority 
        { 
            get => Turns; 
            set => Turns = value; 
        }

        public Person(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }

        public override string ToString()
        {
            return $"{Name} (Turns/Priority: {Turns})";
        }
    }
}

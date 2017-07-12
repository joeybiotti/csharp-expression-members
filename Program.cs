using System;
using System.Collections.Generic;

namespace expression_members
{
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public ICollection<string> Predators { get; } = new List<string>();
        public ICollection<string> Prey { get; } = new List<string>();

        public string FormalName => $"A {this.Name} is an {this.Species}";

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        public string PreyList => string.Join(",", this.Prey);
        
        public string PredatorList => string.Join("," , this.Predators);

        public string Eat(string food) => (this.Prey.Contains(food) ? $"The {this.Name} ate the {food}" : $"The {this.Name} is still hungry");
        static void Main(string[] args)
        {
            List<string> Predators = new List <string>{"lions", "tigers", "bears"};
            List<string> Prey = new List <string>{"rabbit", "grasshopper", "human", "trash"};
            Bug spider = new Bug(name:"spider", species:"arachnid", predators: Predators, prey: Prey);
            Bug fly = new Bug(name: "fly", species:"insect", predators: Predators, prey: Prey);
            Console.WriteLine(spider.Eat("human"));
            Console.WriteLine(spider.Eat("fly"));
            Console.WriteLine(spider.FormalName);
            Console.WriteLine(fly.Eat("lions"));
            Console.WriteLine(fly.Eat("trash"));
            Console.WriteLine(fly.FormalName);
        }
    }
}

// inspired by my imagination

namespace Pattern.Factory
{    
    public interface IAnimal
    {
        int X { get; set; }
        int Y { get; set; }
        int Health { get; set; }
        string Species { get; set; }
        string Name { get; set; }
        void Spawn(string name);
        void MakeVoice();
        void Move(int dx, int dy);
    }

    public class Dog : IAnimal
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }
        public string Species { get; set; }
        public string Name { get; set; }

        public Dog()
        {
            Species = "Dog";
            Name = "...";
        }

        public void Spawn(string name)
        {
            X = 0;
            Y = 0;
            Health = 100;
            Name = name;
        }

        public void MakeVoice()
        {
            Console.WriteLine("Woof!");
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

    public class Cat : IAnimal
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }
        public string Species { get; set; }
        public string Name { get; set; }

        public Cat()
        {
            Species = "Cat";
            Name = "...";
        }

        public void Spawn(string name)
        {
            X = 0;
            Y = 0;
            Health = 80;
            Name = name;
        }

        public void MakeVoice()
        {
            Console.WriteLine("Meow!");
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

    public class Farm
    {
        public IAnimal[] Animals;
        public Farm()
        {
            Animals = new IAnimal[0];
        }
        public IAnimal AddAnimal(string type, string name)
        {
            switch (type)
            {
                case "Dog":
                    var newDog = new Dog();
                    newDog.Spawn(name);
                    Array.Resize(ref Animals, Animals.Length + 1);
                    Animals[Animals.Length - 1] = newDog;
                    return newDog;
                case "Cat":
                    var newCat = new Cat();
                    newCat.Spawn(name);
                    Array.Resize(ref Animals, Animals.Length + 1);
                    Animals[Animals.Length - 1] = newCat;
                    return newCat;
                default:
                    throw new Exception("Unknown animal type");
            }
        }

        public void ListAnimals()
        {
            Console.WriteLine("Animals:");
            foreach (var animal in Animals)
            {
                Console.WriteLine($"- {animal.Species}: '{animal.Name}'");
            }
        }
    }

    public class Factory : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nFactory example\n");
            
            var farm = new Farm();
            var Dog1 = farm.AddAnimal("Dog", "Boccolie");
            Dog1.MakeVoice();
            Dog1.Move(10, 10);

            var Cat1 = farm.AddAnimal("Cat", "Orange");
            Cat1.MakeVoice();
            Cat1.Move(10, 10);

            farm.ListAnimals();
        }
    }
}


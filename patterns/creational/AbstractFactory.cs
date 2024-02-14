// inspired by minecraft

namespace Pattern.AbstractFactory
{
    public class Terrain
    {
        public string[] terrains;
        public Terrain(string biome)
        {
            switch (biome)
            {
                case "forest":
                    terrains = new string[] { "montain", "river", "woods", "lake", "rock" };
                    break;
                case "desert":
                    terrains = new string[] { "plain", "rocks" };
                    break;
                default:
                    terrains = new string[] { "grass", "rocks" };
                    break;
            }
        }
    }

    public class Animal
    {
        public string[] animals;
        public Animal(string biome)
        {
            switch (biome)
            {
                case "forest":
                    animals = new string[] { "bear", "wolf", "deer", "rabbit", "fox" };
                    break;
                case "desert":
                    animals = new string[] { "snake", "scorpion", "lizard" };
                    break;
                default:
                    animals = new string[] { "bear", "wolf", "deer", "rabbit", "fox" };
                    break;
            }
        }
    }

    public class Plant
    {
        public string[] plants;
        public Plant(string biome)
        {
            switch (biome)
            {
                case "forest":
                    plants = new string[] { "oak", "berry", "grass", "flower" };
                    break;
                case "desert":
                    plants = new string[] { "cactus", "grass" };
                    break;
                default:
                    plants = new string[] { "tree", "bush", "grass" };
                    break;
            }
        }
    }

    public interface IBiomeFactory
    {
        Terrain SpawnTerrain();
        Animal SpawnAnimal();
        Plant SpawnPlant();
    }

    public class ForestBiomeFactory : IBiomeFactory
    {
        public Terrain SpawnTerrain()
        {
            return new Terrain("forest");
        }

        public Animal SpawnAnimal()
        {
            return new Animal("forest");
        }

        public Plant SpawnPlant()
        {
            return new Plant("forest");
        }
    }

    public class DesertBiomeFactory : IBiomeFactory
    {
        public Terrain SpawnTerrain()
        {
            return new Terrain("desert");
        }

        public Animal SpawnAnimal()
        {
            return new Animal("desert");
        }

        public Plant SpawnPlant()
        {
            return new Plant("desert");
        }
    }

    public class AbstractFactory : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nAbstractFactory example\n");

            IBiomeFactory forest = new ForestBiomeFactory();
            IBiomeFactory desert = new DesertBiomeFactory();

            Terrain forestTerrain = forest.SpawnTerrain();
            Animal forestAnimal = forest.SpawnAnimal();
            Plant forestPlant = forest.SpawnPlant();
            Console.WriteLine("Forest terrains: " + string.Join(", ", forestTerrain.terrains));
            Console.WriteLine("Forest animals: " + string.Join(", ", forestAnimal.animals));
            Console.WriteLine("Forest plants: " + string.Join(", ", forestPlant.plants));

            Terrain desertTerrain = desert.SpawnTerrain();
            Animal desertAnimal = desert.SpawnAnimal();
            Plant desertPlant = desert.SpawnPlant();
            Console.WriteLine("Desert terrains: " + string.Join(", ", desertTerrain.terrains));
            Console.WriteLine("Desert animals: " + string.Join(", ", desertAnimal.animals));
            Console.WriteLine("Desert plants: " + string.Join(", ", desertPlant.plants));
        }
    }
}
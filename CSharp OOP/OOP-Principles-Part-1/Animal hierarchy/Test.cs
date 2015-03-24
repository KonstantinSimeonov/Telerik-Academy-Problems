using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    // felt like generating some random animals

    public const int numberOfAnimals = 20; // for more/less animals, just change the value

    public const int maxAge = 15; // constrains the rng when generating age
    public const int animalTypes = 4; // used in the output

    public static string[] animalStrings = { "Dogs", "Frogs", "Kittens", "Tomcats" }; // used to format the output of the average age

    // hardcoded names

    public static string[] names ={ 
                                        "Gosho",
                                        "Tosho",
                                        "Pesho",
                                        "Richard",
                                        "Ivan",
                                        "Kircho",
                                        "Petko",
                                        "Boris",
                                        "Genadii",
                                        "Grigor",
                                        "Pancho"
                                    };

    public static string[] femNames = {
                                        "Gigorka",
                                        "Stamatka",
                                        "Galina",
                                        "Mariika",
                                        "Dimitrichka",
                                        "Neli",
                                        "Todorka",
                                        "Latinka",
                                        "Penka",
                                        };

    // rng, sexes array used by the rng
    public static Random rnd = new Random();
    private static Sex[] sexes = { Sex.Female, Sex.Male };
    private static int seed;

    // keeps the sum of the years and the number of specimens for each kind of animal
    public static uint[] animalsCountAndAges = new uint[animalTypes * 2]; 
                                                                            

    // generates random animals

    public static Animal GetRandomAnimal()
    {
        seed = rnd.Next(1, 5);

        switch (seed)
        {
            case 1:
                Sex s = sexes[rnd.Next(0, sexes.Length)]; // get random sex for the animal
                // give the animal a name corresponding to its sex
                string name = s == Sex.Male ? names[rnd.Next(0, names.Length)] : femNames[rnd.Next(0, femNames.Length)];
                // create new animal
                var doge = new Dog(name, s, (uint)rnd.Next(0, maxAge));
                // add his years in the years array
                animalsCountAndAges[0] += doge.Age;
                animalsCountAndAges[1]++;
                // return the new animal
                return doge;

            case 2:
                Sex frogS = sexes[rnd.Next(0, sexes.Length)];
                string frogName = frogS == Sex.Male ? names[rnd.Next(0, names.Length)] : femNames[rnd.Next(0, femNames.Length)];

                var froge = new Frog(frogName, frogS, (uint)rnd.Next(0, maxAge));

                animalsCountAndAges[2] += froge.Age;
                animalsCountAndAges[3]++;

                return froge;

            case 3:
                var kitty = new Kitten(femNames[rnd.Next(0, femNames.Length)], (uint)rnd.Next(0, maxAge));

                animalsCountAndAges[4] += kitty.Age;
                animalsCountAndAges[5]++;

                return kitty;

            case 4:
                var tommy = new Tomcat(names[rnd.Next(0, names.Length)], (uint)rnd.Next(0, maxAge));

                animalsCountAndAges[6] += tommy.Age;
                animalsCountAndAges[7]++;

                return tommy;

            default: throw new ArgumentException("Invalid seed");
        }
    }

    static void Main()
    {

        var animals = new Animal[numberOfAnimals];

        // fill the array with random animals
        for (int i = 0; i < animals.Length; i++)
        {
            animals[i] = GetRandomAnimal();
        }

        // print the animals
        // Console.WriteLine(string.Join("\n", (object[])animals));


        // print their average age

        for (int i = 0; i < animalsCountAndAges.Length; i += 2)
        {
            Console.WriteLine("{0} {1:0.00}", animalStrings[i / 2], animalsCountAndAges[i] / (double)animalsCountAndAges[i + 1]);
        }

    }
}


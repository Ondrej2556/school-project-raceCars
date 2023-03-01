using System;
using System.Threading;

namespace ProjektPraxe1
{
    // Abstraktní třída Vehicle
    public abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public int NumOfPassanger { get; set; }

        public Vehicle(string make, string model, int year, int power, int numOfPassanger)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Power = power;
            this.NumOfPassanger = numOfPassanger;
        }

        // Virtuální metoda pro získání informací o vozidle
        public virtual string GetInfo()
        {
            return $"Info:\nVyrobce: {Make}\nModel: {Model}\nRok vyroby: {Year}\nVykon: {Power}";
        }
    }

    // Třída Car odvozená od třídy Vehicle
    public class Car : Vehicle
    {
        public string Color { get; set; }

        public Car(string make, string model, int year, int power, int numOfPassanger, string color ) : base(make, model, year, power, numOfPassanger)
        {
            this.Color = color;
        }

        // Přepsání virtuální metody GetInfo pro třídu Car
        public override string GetInfo()
        {
            return base.GetInfo() + $"\nBarva: {Color}";
        }
    }

    // Třída Sedan odvozená od třídy Car
    public class Sedan : Car
    {
        public Sedan(string make, string model, int year, int power, int numOfPassanger, string color) : base(make, model, year, power, numOfPassanger, color) { }

        // Přepsání virtuální metody GetInfo pro třídu Sedan
        public override string GetInfo()
        {
            return "Sedan:\n" + base.GetInfo();
        }
    }

    // Třída Combi odvozená od třídy Car
    public class Combi : Car
    {
        public Combi(string make, string model, int year, int power, int numOfPassanger, string color) : base(make, model, year, power, numOfPassanger,color) { }

        // Přepsání virtuální metody GetInfo pro třídu Combi
        public override string GetInfo()
        {
            return "Combi:\n" + base.GetInfo();
        }
    }

    // Třída Bus odvozená od třídy Vehicle
    public class Bus : Vehicle
    {
        public int Capacity { get; set; }

        public Bus(string make, string model, int year, int maxSpeed,int numOfPassanger, int capacity) : base(make, model, year, maxSpeed, numOfPassanger)
        {
            Capacity = capacity;
        }

        // Přepsání virtuální metody GetInfo pro třídu Bus
        public override string GetInfo()
        {
            return "Bus:\n" + base.GetInfo() + $"\nPocet vozidel: {Capacity}";
        }
    }

    // Třída Train odvozená od třídy Vehicle
    public class Train : Vehicle
    {
        //Pocet vagonu
        public int NumCars { get; set; }

        public Train(string make, string model, int year, int maxSpeed, int numOfPassanger, int numCars) : base(make, model, year, maxSpeed, numOfPassanger)
        {
            NumCars = numCars;
        }

        // Přepsání virtuální metody GetInfo pro třídu Train
        public override string GetInfo()
        {
            return "Train:\n" + base.GetInfo() + $"\nPocet vagonu {NumCars}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Závodní hra");
            Console.WriteLine("Vyber si vozidlo, nakonfigruju a vyhrej zavod!");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\nVyber si první vozidlo:");
            Console.WriteLine(" 1. auto - sedan");
            Console.WriteLine(" 2. auto - kombik");
            Console.WriteLine(" 3. Autobus");
            Console.WriteLine(" 4. Vlak");

            int choice1;
            while (!int.TryParse(Console.ReadLine(), out choice1) || choice1 < 1 ||choice1 > 4)
            {
                Console.WriteLine("Nesprávně zadaná hodnota");
            }

            Vehicle vehicle1 =  getVehicle(choice1);
            Console.WriteLine("\nPrvni zvolene vozidlo: ");
            Console.WriteLine(vehicle1.GetInfo());

            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("\nVyber si druhe vozidlo:");
            Console.WriteLine(" 1. auto - sedan");
            Console.WriteLine(" 2. auto - kombik");
            Console.WriteLine(" 3. Autobus");
            Console.WriteLine(" 4. Vlak");

            int choice2;
            while (!int.TryParse(Console.ReadLine(), out choice2) || choice2 < 1 || choice2 > 4)
            {
                Console.WriteLine("Nesprávně zadaná hodnota");
            }
            Vehicle vehicle2 = getVehicle(choice2);
            Console.WriteLine("\nDruhe zvolene vozidlo: ");
            Console.WriteLine(vehicle2.GetInfo());

            Console.WriteLine("Stisknete cokoliv pro zahajeni zavodu");
            Console.ReadKey();


            zavod(vehicle1.Model, vehicle2.Model, vehicle1.Power, vehicle2.Power,vehicle1.NumOfPassanger , vehicle2.NumOfPassanger, vehicle1.Year, vehicle2.Year);




            Console.ReadKey();
        }


        

        public static void zavod (string vehicleType1, string vehicleType2, int vehiclePower1, int vehiclePower2, int vehiclePassanger1, int vehiclePassanger2, int vehicleYear1, int vehicleYear2)
        {
            int coefficientVehicle1 = getVehicleCoefficient( vehiclePower1, vehiclePassanger1, vehicleYear1);
            int coefficientVehicle2 = getVehicleCoefficient(vehiclePower2, vehiclePassanger2, vehicleYear2);

            Console.Clear();
            int vehiclePointsInRace1 = 0;
            int vehiclePointsInRace2 = 0;
            int raceTime = 10;
            Console.WriteLine($"Zavod na {raceTime} sekund");
            Console.WriteLine("\nStart");
            Console.WriteLine("");
            for (int i = 0; i <= 10; i++)
            {
                Console.SetCursorPosition(1, 3);
                Console.WriteLine($"Závod {i}s");
                Console.WriteLine("");
                Console.SetCursorPosition(1, 5);
                Console.Write(vehicleType1);
                Console.SetCursorPosition(15, 5);
                for (int j = 0; j < i* coefficientVehicle1; j++)
                {
                    vehiclePointsInRace1 += 1;
                    Console.Write("-");
                }
                Console.SetCursorPosition(1, 7);
                Console.Write(vehicleType2);
                Console.SetCursorPosition(15, 7);
                for (int j = 0; j < i* coefficientVehicle2; j++)
                {
                    vehiclePointsInRace2 += 1;
                    Console.Write("-");
                }
                System.Threading.Thread.Sleep(1000);
            }


            Console.WriteLine("\nVýherce závodu je " + ((vehiclePointsInRace1 > vehiclePointsInRace2) ? vehicleType1 : vehicleType2));
            Console.ReadLine();
        }


        //Calculate how fast will vehicle go in a race
        public static int getVehicleCoefficient(int vehiclePower, int vehiclePassanger, int vehicleYear)
        {
            int vehicleAge = vehicleYear == DateTime.Now.Year ? vehicleYear : DateTime.Now.Year - vehicleYear;
            int vehicleSpeed;
            int coefficient;
            if (vehiclePower >= 300 && vehiclePassanger <=2 && vehicleAge <= 4)
            {
               coefficient = 3;
               
            } else if ( vehiclePower >= 81 && vehiclePower < 300 && vehicleAge < 20)
            {
                coefficient = 1;
            } else
            {
                coefficient = 0;
            }

            Random random = new Random();
            vehicleSpeed = random.Next(1, 3) + coefficient;
            
  
            return vehicleSpeed;
        }

        public static Vehicle  getVehicle (int choice)
        {
            if (choice == 1)
            {
                Console.WriteLine("První auto závodu bude sedan");
                Console.WriteLine("Zadej výrobce auta: ");
                string maker = Console.ReadLine();
                Console.WriteLine("Zadej model auta: ");
                string model = Console.ReadLine();
                Console.WriteLine("Zadej barvu auta: ");
                string color = Console.ReadLine();

                Sedan sedan1 = new Sedan(maker, model, getVehicleValues("rok výroby", 1886, DateTime.Now.Year), getVehicleValues("výkon auta", 20, 500), getVehicleValues("pocet pasazeru", 1, 5),color);
                return sedan1;
            }
            else if (choice == 2)
            {
                Console.WriteLine("První auto závodu bude kombik");
                Console.WriteLine("Zadej výrobce auta: ");
                string maker = Console.ReadLine();
                Console.WriteLine("Zadej model auta: ");
                string model = Console.ReadLine();
                Console.WriteLine("Zadej barvu auta: ");
                string color = Console.ReadLine();

                Combi combi1 = new Combi(maker, model, getVehicleValues("rok výroby", 1886, DateTime.Now.Year), getVehicleValues("výkon auta", 20, 500), getVehicleValues("pocet pasazeru", 1, 5),color);
                 return combi1;
            }
            else if (choice == 3)
            {
                Console.WriteLine("První auto závodu bude autobus");
                Console.WriteLine("Zadej výrobce autobusu: ");
                string maker = Console.ReadLine();
                Console.WriteLine("Zadej model autobusu: ");
                string model = Console.ReadLine();

                Bus bus1 = new Bus(maker, model, getVehicleValues("rok výroby", 1895, DateTime.Now.Year), getVehicleValues("výkon autobusu", 20, 500), getVehicleValues("pocet pasazeru", 1, 30), getVehicleValues("pocet privesu",0,2));
                return bus1;
            }
            else
            {
                Console.WriteLine("První auto závodu bude vlak");
                Console.WriteLine("Zadej výrobce Vlaku: ");
                string maker = Console.ReadLine();
                Console.WriteLine("Zadej model Vlaku: ");
                string model = Console.ReadLine();

                Train train1 = new Train(maker, model, getVehicleValues("rok výroby", 1769, DateTime.Now.Year), getVehicleValues("výkon vlaku", 20, 500), getVehicleValues("pocet cestujicich", 1, 120),getVehicleValues("pocet vagonu",1,30));
                return train1;
            }
        }

        public static int getVehicleValues(string type, int min, int max)
        {

            Console.WriteLine($"Zadej {type}. min: {min}; max: {max}: ");
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.WriteLine("Nesprávně zadaná hodnota");
                Console.WriteLine("Zadej hodnotu znova");
            }
            return value;
        }
        



    }
}

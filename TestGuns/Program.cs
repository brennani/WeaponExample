using System;
using System.Collections.Generic;

namespace WeaponExample
{



    public class Program
    {
        // here is our weapon store, all weapons that exist that have been used by the player can go here
        private static List<Weapon> WeaponStore = new List<Weapon>();
        
        // this represents our currently held weapon
        private static Weapon currentInventoryWeapon = null;

        static void Main(string[] args)
        {
            // add weapons to the weapon store
            WeaponStore.Add(new PeaShooter());
            WeaponStore.Add(new MiniGun());
            WeaponStore.Add(new SorcererStaff());
            
            // enter game loop
            RunSimulation();
        }

        private static void RunSimulation()
        {
            Console.WriteLine("Hello and welcome to the firing range!");
            
            // using $ in front of a string makes it "interpolated" -> meaning we can put variables in it and they get resolved at runtime
            // see the curly brackets {}
            Console.WriteLine($"We have {WeaponStore.Count} weapons available to try today:");

            foreach (var weapon in WeaponStore)
                Console.WriteLine("\n" + weapon.ToString());

            // when writing to a console "\n" indicates "new line" character, and "\t" indicates a tab character
            Console.WriteLine("\n\nYou can choose from the following options:"
                + "\n\tfire -> Fires the current weapon."
                + "\n\tswap -> Swaps to the next weapon in the store."
                + "\n\tcheck -> Checks the current weapon's stats."
                + "\n\tquit -> Leaves the store.");

            string currentCommand = "";
            while(currentCommand != "quit") { 

                Console.WriteLine("Please enter your next selection: ");
                currentCommand = Console.ReadLine();

                switch(currentCommand)
                {
                    // tries to fire if there is a weapon
                    case "fire":
                        if (currentInventoryWeapon == null)
                        {
                            Console.WriteLine("You haven't swapped to any weapon yet!");
                        }
                        else
                        {                            
                            Console.WriteLine($"You fire the {currentInventoryWeapon.Name}");
                            currentInventoryWeapon.Fire();
                            if (currentInventoryWeapon.Degradable)
                                Console.WriteLine($"It's durability is now: {currentInventoryWeapon.Durability}");
                        }
                        break;
                    // swaps to the next weapon
                    case "swap":
                        // find the index of the currently selected weapon, if there isn't one it returns -1
                        int selectedIndex = WeaponStore.FindIndex(x => x == currentInventoryWeapon);

                        // if the selected index is the last one, set it back to 0, otherwise increase it by one
                        selectedIndex = (selectedIndex >= WeaponStore.Count - 1 ? 0 : selectedIndex + 1);

                        // set the current weapon
                        currentInventoryWeapon = WeaponStore[selectedIndex];

                        Console.WriteLine($"Swapped to {currentInventoryWeapon.Name}");
                        break;
                    // prints out the current weapon's information
                    case "check":
                        Console.WriteLine("Current Weapon: \n" + currentInventoryWeapon.ToString());
                        break;
                    case "quit":
                        Console.WriteLine("Seeya later!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Sorry, I don't know what that means.");
                        Console.WriteLine("Please choose from the following options:"
    + "\n\tfire -> Fires the current weapon."
    + "\n\tswap -> Swaps to the next weapon in the store."
    + "\n\tcheck -> Checks the current weapon's stats."
    + "\n\tquit -> Leaves the store.");
                        break;
                }
            }

        }

    }
}

using System;
using System.Collections.Generic;

namespace WeaponExample
{



    public class Program
    {
        private static List<Weapon> WeaponStore = new List<Weapon>();

        private static Weapon currentInventoryWeapon = null;

        static void Main(string[] args)
        {
            // add a minigun and a staff to our weapon store (not the player inventory)
            WeaponStore.Add(new PeaShooter());
            WeaponStore.Add(new MiniGun());
            WeaponStore.Add(new SorcererStaff());

            RunSimulation();
        }

        private static void RunSimulation()
        {
            // can swap weapon
            // can fire
            // can exhaust ammo
            Console.WriteLine("Hello and welcome to the firing range!");
            Console.WriteLine($"We have {WeaponStore.Count} weapons available to try today:");

            foreach (var weapon in WeaponStore)
                Console.WriteLine("\n" + weapon.ToString());

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
                    case "swap":
                        // find the index of the currently selected weapon, if there isn't one it returns -1
                        int selectedIndex = WeaponStore.FindIndex(x => x == currentInventoryWeapon);

                        // if the selected index is the last one, set it back to 0, otherwise increase it by one
                        selectedIndex = (selectedIndex >= WeaponStore.Count - 1 ? 0 : selectedIndex + 1);

                        // set the current weapon
                        currentInventoryWeapon = WeaponStore[selectedIndex];

                        Console.WriteLine($"Swapped to {currentInventoryWeapon.Name}");
                        break;
                    case "check":
                        Console.WriteLine("Current Weapon: \n" + currentInventoryWeapon.ToString());
                        break;
                    case "quit":
                        Console.WriteLine("Seeya later!");
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

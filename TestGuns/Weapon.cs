using System;

namespace WeaponExample
{
    public abstract class Weapon
    {
        public string Name = "DEFAULT_WEAPON_NAME";
        public bool Automatic = false;
        public int Magazine_Max = 1;
        public int Ammo_Max = 1;
        public float ROF = 1;
        public bool Degradable = false;
        public int Durability = -1;

        public int CurrentAmmoCount = 0;
        public int CurrentMagazineCount = 0;

        public void Fire()
        {
            if(Durability == 0)
            {
                Console.WriteLine(Name + " is broken!");
                return;
            }
            
            if(CurrentAmmoCount < 1) 
            {
                Console.WriteLine(Name + " is out of ammo!");
                return;
            }

            if (CurrentMagazineCount > 0)
                CurrentMagazineCount--;
            else if(CurrentAmmoCount > 0)
                Reload();

            if (Degradable)
            {
                Durability--;
            }
        }

        public void Reload()
        {
            Console.WriteLine("Reloading...!");
            CurrentMagazineCount += Math.Min(Magazine_Max, CurrentAmmoCount);
            CurrentAmmoCount -= CurrentMagazineCount;
        }

        public override string ToString()
        {
            return
                $"\t{Name}: "
                + $"\n\t\tMax Ammo: {Ammo_Max}"
                + $"\n\t\tCurrent Ammo: {CurrentAmmoCount}"
                + $"\n\t\tMagazine Capacity: {Magazine_Max}"
                + (Degradable ? $"\n\t\tDurability: {Durability}" : "")
                + $"\n\t\tFunction: " + (Automatic ? "Full-Auto" : "Single Round")
                + (Automatic ? $"\n\t\t\tROF: {ROF}" : "");
        }

    }
}

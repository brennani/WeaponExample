namespace WeaponExample
{
    public class SorcererStaff : Weapon
    {

        public SorcererStaff()
        {
            Name = "Sorcerer's Staff";
            Automatic = false;
            Magazine_Max = 10;
            Ammo_Max = 100;
            ROF = 1;
            Degradable = true;
            Durability = 100;

            CurrentAmmoCount = 100;
            CurrentMagazineCount = 10;

        }

    }
}

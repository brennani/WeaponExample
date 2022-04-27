namespace WeaponExample
{
    public class MiniGun : Weapon
    {

        public MiniGun()
        {
            Name = "MiniGun";
            Automatic = true;
            Magazine_Max = 1000;
            Ammo_Max = 1000;
            ROF = 20;
            Degradable = true;
            Durability = 750;

            CurrentAmmoCount = 1000;
            CurrentMagazineCount = 1000;
        }

    }
}

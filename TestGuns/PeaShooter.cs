namespace WeaponExample
{
    public class PeaShooter : Weapon
    {
        public PeaShooter()
        {
            Name = "Pea Shooter";
            Automatic = false;
            Magazine_Max = 1;
            Ammo_Max = 15;
            ROF = 1;
            Degradable = false;
            Durability = -1;

            CurrentAmmoCount = 15;
            CurrentMagazineCount = 1;
        }
    }
}

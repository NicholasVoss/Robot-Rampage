using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Game game;
    public AudioClip playerDead;
    public int health;
    public int armor;
    public GameUI gameUI;
    private GunEquipper gunEquipper;
    private Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        //get ammo and gun equipper components
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
    }

    //deals damage to player
    public void TakeDamage(int amount)
    {
        int healthDamage = amount;

        //check if player has armour
        if (armor > 0)
        {
            int effectiveArmor = armor * 2;
            effectiveArmor -= healthDamage;

            //if player has armour, player takes no damage, but armour is damaged
            if (effectiveArmor > 0)
            {
                armor = effectiveArmor / 2;
                gameUI.SetArmorText(armor);
                return;
            }

            //if player runs out of armour, continue dealing damage
            armor = 0;
            gameUI.SetArmorText(armor);
        }

        //damage player
        health -= healthDamage;
        gameUI.SetHealthText(health);

        //if player runs out of health, play death sound and end the game
        if(health <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(playerDead);
            game.GameOver();
        }
    }

    //heals player after picking up health
    private void pickupHealth()
    {
        health += 50;

        //if player's health goes over the health limit, set the health to the max amount
        if (health > 200)
        {
            health = 200;
        }

        //updates UI
        gameUI.SetPickupText("Health picked up +50 Health");
        gameUI.SetHealthText(health);
    }

    //adds armour after picking up armour powerup
    private void pickupArmor()
    {
        armor += 15;
        //updates UI
        gameUI.SetPickupText("Armor picked up +15 armor");
        gameUI.SetArmorText(armor);
    }

    //adds assault rifle ammo
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
        //updates UI
        gameUI.SetPickupText("Assault rifle ammo picked up +50 ammo");
        if(gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.AssaultRifle));
        }
    }
    //adds pistol ammo
    private void pickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
        //updates UI
        gameUI.SetPickupText("Pistol ammo picked up +20 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Pistol)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Pistol));
        }
    }
    //adds shotgun ammo
    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
        //updates UI
        gameUI.SetPickupText("Shotgun ammo picked up +10 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Shotgun)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Shotgun));
        }
    }
    //adds rocket ammo
    private void pickupRocketAmmo()
    {
        ammo.AddAmmo(Constants.Rocket, 2);
        //updates UI
        gameUI.SetPickupText("Rocket ammo picked up +2 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Rocket)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Rocket));
        }
    }

    //when the player grabs a pickup, apply the pickup's effects
    public void PickUpItem(int pickupType)
    {
        switch (pickupType)
        {
            case Constants.PickUpArmor:
                pickupArmor();
                break;
            case Constants.PickUpHealth:
                pickupHealth();
                break;
            case Constants.PickUpAssaultRifleAmmo:
                pickupAssaultRifleAmmo();
                break;
            case Constants.PickUpPistolAmmo:
                pickupPistolAmmo();
                break;
            case Constants.PickUpShotgunAmmo:
                pickupShotgunAmmo();
                break;
            case Constants.PickUpRocketAmmo:
                pickupRocketAmmo();
                break;
            default:
                UnityEngine.Debug.LogError("Bad pickup type passed" + pickupType);
                break;
        }
    }
}

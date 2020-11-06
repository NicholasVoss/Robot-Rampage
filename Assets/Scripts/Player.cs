using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }

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
                return;
            }
            armor = 0;
        }

        //damage player
        health -= healthDamage;
        UnityEngine.Debug.Log("Health is " + health);

        //if player runs out of health, game over
        if(health <= 0)
        {
            UnityEngine.Debug.Log("GameOver");
        }
    }

    //heals player after picking up health
    private void pickupHealth()
    {
        health += 50;
        if(health > 200)
        {
            health = 200;
        }
    }

    //adds armour after picking up armour powerup
    private void pickupArmor()
    {
        armor += 15;
    }

    //adds ammo
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
    }
    private void pickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
    }
    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
    }

    //add armor/health/ammo when player picks them up
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
            default:
                UnityEngine.Debug.LogError("Bad pickup type passed" + pickupType);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{
    //used for reticle
    [SerializeField]
    GameUI gameUI;

    public static string activeWeaponType;

    //guns the player can use
    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;
    public GameObject rocket;

    //currently equipped gun
    GameObject activeGun;

    [SerializeField]
    Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
            gameUI.UpdateReticle();
        }
        else if(Input.GetKeyDown("2"))
        { 
            loadWeapon(assaultRifle);
            activeWeaponType = Constants.AssaultRifle;
            gameUI.UpdateReticle();
        }
        else if(Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
            gameUI.UpdateReticle();
        }
        else if (Input.GetKeyDown("4"))
        {
            loadWeapon(rocket);
            activeWeaponType = Constants.Rocket;
            gameUI.UpdateReticle();
        }
    }

    private void loadWeapon(GameObject weapon)
    {
        //disables all guns
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);
        rocket.SetActive(false);

        //enables gun the player wants to switch to
        weapon.SetActive(true);
        activeGun = weapon;

        gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));
    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}

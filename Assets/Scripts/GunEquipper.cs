using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{

    public static string activeWeaponType;

    //guns the player can use
    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;

    //currently equipped gun
    GameObject activeGun;

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
        }
        else if(Input.GetKeyDown("2"))
        { 
            loadWeapon(assaultRifle);
            activeWeaponType = Constants.AssaultRifle;
        }
        else if(Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
        }
    }

    private void loadWeapon(GameObject weapon)
    {
        //disables all guns
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);

        //enables gun the player wants to switch to
        weapon.SetActive(true);
        activeGun = weapon;
    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}

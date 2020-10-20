using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;

    [SerializeField]
    private int pistolAmmo = 20;
    [SerializeField]
    private int shotgunAmmo = 10;
    [SerializeField]
    private int assaultRifleAmmo = 50;

    public Dictionary<string, int> tagToAmmo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        tagToAmmo = new Dictionary<string, int>
        {
            {Constants.Pistol , pistolAmmo },
            {Constants.Shotgun , shotgunAmmo },
            {Constants.AssaultRifle , assaultRifleAmmo },
        };
    }

    //increases amount of ammo
    public void AddAmmo(string tag, int ammo)
    {
        if(!tagToAmmo.ContainsKey(tag))
        {
            UnityEngine.Debug.LogError("Unrecognized gun type passed: " + tag);
        }

        tagToAmmo[tag] += ammo;
    }

    //returns true if gun has ammo left
    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            UnityEngine.Debug.LogError("Unrecognized gun type passed: " + tag);
        }

        return tagToAmmo[tag] > 0;
    }

    //returns bullet count
    public int GetAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            UnityEngine.Debug.LogError("Unrecognized gun type passed: " + tag);
        }

        return tagToAmmo[tag];
    }

    //decreases ammo by 1
    public void ConsumeAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            UnityEngine.Debug.LogError("Unrecognized gun type passed: " + tag);
        }

        tagToAmmo[tag]--;
    }
}

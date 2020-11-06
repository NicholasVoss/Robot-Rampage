using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pickups;

    //creates a pickup
    void spawnPickup()
    {
        GameObject pickup = Instantiate(pickups[UnityEngine.Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
    }

    //respawn the pickup after 20 seconds
    IEnumerator respawnPickup()
    {
        yield return new WaitForSeconds(20);
        spawnPickup();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPickup();
    }

    //when pickup has been picked up, start respawning it
    public void PickupWasPickedUp()
    {
        StartCoroutine("respawnPickup");
    }
}

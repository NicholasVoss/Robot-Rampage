using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //run when something collides with pickup
    void OnTriggerEnter(Collider collider)
    {
        //check if it was the player that collided
        if(collider.gameObject.GetComponent<Player>() != null && collider.gameObject.tag == "Player")
        {
            //player picks up the pickup
            collider.gameObject.GetComponent<Player>().PickUpItem(type);
            GetComponentInParent<PickupSpawn>().PickupWasPickedUp();
            Destroy(gameObject);
        }
    }
}

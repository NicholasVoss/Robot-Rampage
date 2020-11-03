using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("deathTimer");
    }

    // Update is called once per frame
    void Update()
    {
        //move the missile
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator deathTimer()
    {
        //destroy the missile if it does not hit anything after 10 seconds
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    //check if missile hits something
    void OnCollisionEnter(Collision collider)
    {
        //if missile hits player, damage player
        if(collider.gameObject.GetComponent<Player>() != null && collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Player>().TakeDamage(damage);
        }

        //destroy missile
        Destroy(gameObject);
    }
}

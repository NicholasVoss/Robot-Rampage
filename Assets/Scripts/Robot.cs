using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    GameObject missileprefab;

    [SerializeField]
    private string robotType;

    public int health;

    //vars for firing bullets
    public int range;
    public float fireRate;

    //used for animations
    public Animator robot;

    public Transform missleFireSpot;
    UnityEngine.AI.NavMeshAgent agent;

    private Transform player;
    private float timeLastFired;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        //get components for navmesh agent and player
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //dont continue if robot is dead
        if(isDead)
        {
            return;
        }

        //robot looks towards player
        transform.LookAt(player);

        //use the navmesh to find a path to the player
        agent.SetDestination(player.position);

        //check if player is close enough to shoot and if enough time has passed since the last shot
        //if true, fire
        if(Vector3.Distance(transform.position, player.position) < range && Time.time - timeLastFired > fireRate)
        {
            timeLastFired = Time.time;
            fire();
        }
    }

    private void fire()
    {
        //creates and shoots a missile
        GameObject missile = Instantiate(missileprefab);
        missile.transform.position = missleFireSpot.transform.position;
        missile.transform.rotation = missleFireSpot.transform.rotation;
        robot.Play("Fire");
    }
}

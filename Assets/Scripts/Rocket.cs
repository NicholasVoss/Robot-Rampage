using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Gun
{
    override protected void Update()
    {
        base.Update();
        if(Input.GetMouseButtonDown(0) && (Time.time - lastFireTime) > fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}

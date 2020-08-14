using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSeparation : Flee
{
    public float desiredSeparation = 15.0f;
    public List<GameObject> targets;

    public override steering GetSteering()
    {
        steering steer = new steering();
        int count = 0;

        //for each boid in the system, check if it is too close
        foreach(GameObject other in targets)
        {
            if (other != null)
            {
                float d = (transform.position - other.transform.position).magnitude;

                if((d > 0) && (d < desiredSeparation))
                {
                    //calculate vector pointing away from neighbor
                    Vector3 diff = transform.position - other.transform.position;
                    diff.Normalize();
                    diff /= d;
                    steer.linear += diff;
                    count++;
                }
            }
        }//end for

        if(count > 0)
        {
            //steer.linear /= (float)count;
        }

        return steer;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector3 dir;
    public Vector3 scale;
    public float distance;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, scale/2, dir, out hit, transform.rotation, distance))
            Debug.Log(hit.collider.name);
    }

    void  OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, dir * distance);
        //Draw a cube at the maximum distance
        Gizmos.DrawWireCube(transform.position + dir * distance, scale);
    } 
}

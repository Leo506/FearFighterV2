using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour, ISetUpObj
{
    public Transform target; // объект за которым надо следить

    public SpriteRenderer sprite;


    public void SetUp()
    {
        target = FindObjectOfType<Portal>().transform;
    }
    

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Debug.Log(dir);
        var zRot = Mathf.Acos(Vector3.Dot(Vector3.forward, dir) / dir.magnitude) * Mathf.Rad2Deg;

        if (Vector3.Cross(Vector2.up, dir).z < 0)
            zRot *= -1;
        
        transform.rotation = Quaternion.Euler(90, 0, zRot);
    }
}

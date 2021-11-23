﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObj : MonoBehaviour
{
    protected bool canMove = false;
    protected Transform playerTransform;

    public float speed = 100f;

    public void Init()
    {
        playerTransform = FindObjectOfType<PlayerLogic>().transform;
    }

    public void StartMove()
    {
        canMove = true;
    }

    protected void Moving()
    {
        Vector3 dir = (playerTransform.position - this.transform.position).normalized;
        this.transform.Translate(dir * speed * Time.deltaTime);
    }

    protected bool CheckDistance()
    {
        return Vector3.Distance(playerTransform.position, this.transform.position) <= 0.1f;
    }
}

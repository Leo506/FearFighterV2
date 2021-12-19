﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordItem : DroppingObj
{
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Moving();
            if (CheckDistance())
                OnGet();
        }
    }

    protected override void OnGet()
    {
        PlayerLogic.instance.AttackValue *= 1.1f;
        base.OnGet();
    }
}

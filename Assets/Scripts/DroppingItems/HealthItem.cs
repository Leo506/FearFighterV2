using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : DroppingObj
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
        PlayerLogic.instance.CurrentHP += 10;
        base.OnGet();
    }
}

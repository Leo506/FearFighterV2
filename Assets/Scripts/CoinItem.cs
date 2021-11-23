using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : DroppingObj
{
    
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Moving();
            if (CheckDistance())
                Destroy(this.gameObject);
        }
    }
}

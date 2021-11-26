using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueItem : DroppingObj
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

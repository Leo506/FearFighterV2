using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObj : MonoBehaviour, IUsingObj
{

    protected virtual void OnGet()
    {
        Debug.Log("Использование дропа");
        Destroy(this.gameObject);
    }

    public void Use()
    {
        OnGet();
    }
}

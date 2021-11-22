using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IGetDamaged
{
    [SerializeField] CoinController coin;
    public float hp = 100;
    
    public void GetDamage(float value)
    {
        hp -= value;
        Debug.Log("Get damage by " + value + " points");
        if (hp <= 0)
        {
            if (coin != null)
            {
                var obj = Instantiate(coin);
                obj.transform.position = this.transform.position;
                obj.Init();
            }
            Destroy(this.gameObject);
        }
    }
}

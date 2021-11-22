using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IGetDamaged, ISetUpObj
{
    [SerializeField] CoinController coin;
    public float hp = 100;

    PlayerLogic player;
    NavMeshAgent agent;


    private void Update()
    {
        if (agent != null && player != null)
            agent.SetDestination(player.transform.position);
    }

    public void SetUp()
    {
        player = FindObjectOfType<PlayerLogic>();
        agent = GetComponent<NavMeshAgent>();
    }



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

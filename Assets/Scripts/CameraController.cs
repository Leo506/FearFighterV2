using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraController : MonoBehaviour
{
    [SerializeField] Cinemachine.CinemachineVirtualCamera vCamera;

    public static CameraController instance;

    public bool isReverse = false;


    private void Awake()
    {
        if (instance != this && instance != null)
            Destroy(instance.gameObject);

        instance = this;
    }

    public void ChangeView()
    {
        if (!CheckVisibleEnemies())
        {
            var transposer = vCamera.GetCinemachineComponent<Cinemachine.CinemachineTransposer>();
            transposer.m_FollowOffset = new Vector3(transposer.m_FollowOffset.x, transposer.m_FollowOffset.y, -transposer.m_FollowOffset.z);

            if (isReverse)
                vCamera.transform.localRotation = Quaternion.Euler(45, 0, 0);
            else
                vCamera.transform.localRotation = Quaternion.Euler(45, 180, 0);

            foreach (var item in FindObjectsOfType<SpriteRenderer>())
            {
                if (isReverse)
                    item.transform.localRotation = Quaternion.Euler(45, 0, 0);
                else
                    item.transform.localRotation = Quaternion.Euler(45, 180, 0);
            }

            isReverse = !isReverse;
        }
    }


    bool CheckVisibleEnemies()
    {
        int visible = 0;
        int invisible = 0;

        foreach (var item in EnemyController.enemiesOnScene.Where(e => e.IsAngry()).ToList())
        {
            var screenPos = Camera.main.WorldToViewportPoint(item.transform.position);
            if (screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1)
                invisible++;
            else
                visible++;
        }

        return visible >= invisible;
    }
}

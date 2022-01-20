using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, IObserver, ISetUpObj
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider box;
    [SerializeField] Canvas canvas;
    [SerializeField] Pointer pointerPrefab;

    Subject subject;
    bool isActive = false;


    // Переносит игрока к боссу в зависимости от значения параметра transfer
    public void TransferToBoss(bool transfer)
    {
        if (transfer)
            SceneManager.LoadScene("BossFightPhase2");
        else
        {
            ActivatePortal(false);
        }

        Time.timeScale = 1;
    }

    public void SetUp()
    {
        subject = FindObjectOfType<Subject>();
        subject.AddObserver(this);
    }


    public void OnNotify(EventList eventValue)
    {
        // После зачистки уровня рандомим появится ли портал к боссу
        if (eventValue == EventList.NO_ENEMIES)
        {
            if (Random.Range(0, 2) == 0)
            {
                ActivatePortal(true);

                Transform player = FindObjectOfType<PlayerLogic>().transform;
                Instantiate(pointerPrefab, player).SetTarget(this.transform);
            }
        }
    }


    void ActivatePortal(bool active)
    {
        box.enabled = active;
        spriteRenderer.enabled = active;
        isActive = active;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && isActive)
        {
            canvas.enabled = true;
            Time.timeScale = 0;
        }
    }
}

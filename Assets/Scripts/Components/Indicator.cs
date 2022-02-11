using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;


    /// <summary>
    /// Включает индикатор
    /// </summary>
    public void SetIndicator()
    {
        sprite.enabled = true;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        sprite.enabled = false;
    }
}

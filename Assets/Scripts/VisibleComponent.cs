using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleComponent : MonoBehaviour
{

    public static int countOfVisibleObj = 0;

    bool isVisible = true;

    private void Update() 
    {
        Vector3 point = Camera.main.WorldToViewportPoint(this.transform.position);

        if (point.y < 0 || point.y > 1 || point.x > 1 || point.x < 0)
            Debug.Log("Object invisible");
    }

    /// <summary>
    /// OnBecameInvisible is called when the renderer is no longer visible by any camera.
    /// </summary>
    void OnBecameInvisible()
    {
        Debug.Log("Count of visible objects: " + countOfVisibleObj);
        countOfVisibleObj--;
        isVisible = false;
    }


    /// <summary>
    /// OnBecameVisible is called when the renderer became visible by any camera.
    /// </summary>
    void OnBecameVisible()
    {
        Debug.Log("Count of visible objects: " + countOfVisibleObj);
        countOfVisibleObj++;
        isVisible = true;
    }


    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        // Если объект виден, то при уничтожении объекта
        // уменьшаем кол-во видимых объектов
        if (isVisible)
            countOfVisibleObj--;

        Debug.Log("Count of visible objects: " + countOfVisibleObj);
    }
}

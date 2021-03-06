using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveDropComponent : MonoBehaviour
{
    DroppingObj item;


    /// <summary>
    /// Установка префаба дропа, который будет выпадать
    /// </summary>
    /// <param name="obj">Префаб дропа</param>
    public void SetItem(DroppingObj obj)
    {
        item = obj;
    }


    /// <summary>
    /// Выпадение дропа
    /// </summary>
    public void Drop()
    {
        Vector3 pos = new Vector3(this.transform.position.x, item.transform.position.y, this.transform.position.z);
        var obj = Instantiate(item);
        obj.transform.position = pos;

        if (CameraController.instance.isReverse)
            obj.GetComponentInChildren<SpriteRenderer>().transform.localRotation = Quaternion.Euler(45, 180, 0);
    }
}

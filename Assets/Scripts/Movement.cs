using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum viewDirection
{
    UP,
    DOWN,
    RIGHT,
    LEFT,
    NULL
}

public class Movement
{

    /// <summary>
    /// Определяет направление (лево, право, верх, низ) по вектору
    /// </summary>
    /// <param name="dir">Вектор направления</param>
    /// <returns>Одно из четырех направлений</returns>
    public static viewDirection DetermineView(Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
                return viewDirection.RIGHT;
            else if (dir.x < 0)
                return viewDirection.LEFT;
            else
                return viewDirection.NULL;
        }
        else
        {
            if (dir.y > 0)
                return viewDirection.UP;
            else if (dir.y < 0)
                return viewDirection.DOWN;
            else
                return viewDirection.NULL;
        }
    }


    /// <summary>
    /// По положению, размерам коллайдера и направлению взгляда определяет область атаки
    /// </summary>
    /// <param name="box">Коллайдер объекта</param>
    /// <param name="transform">Transform объекта</param>
    /// <param name="dir">Направление "взгляда"</param>
    /// <returns></returns>
    public static Vector2 GetAttackArea(BoxCollider2D box, Transform transform, viewDirection dir)
    {
        float scale = box.size.x * (transform.localScale.x / 2);
        switch (dir)
        {
            case viewDirection.UP:
                return Vector2.up + new Vector2(0, scale);

            case viewDirection.DOWN:
                return Vector2.down + new Vector2(0, -scale);
                
            case viewDirection.RIGHT:
                return Vector2.right + new Vector2(scale, 0);
                
            case viewDirection.LEFT:
                return Vector2.left + new Vector2(-scale, 0);
                
            default:
                return Vector2.zero;                
        }

    }
}

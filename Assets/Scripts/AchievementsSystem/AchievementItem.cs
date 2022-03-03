using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    [SerializeField] Image achieveImage;  // Изображение достижения
    [SerializeField] Button getButton;    // Кнопка получения награды за достижение

    public int id;                        // Id достижения, которое отображает данный UI item

    /// <summary>
    /// Обновляет вид достижения на экране
    /// </summary>
    /// <param name="fill">Процент прогресса достижения</param>
    /// <param name="enable">Доступно ли получение награды</param>
    public void UpdateView(float fill, bool enable)
    {
        achieveImage.fillAmount = fill;
        getButton.enabled = enable;
    }


    /// <summary>
    /// Получение награды
    /// </summary>
    public void GetAward()
    {
        AchievementManager.GetAchievementById(id)?.GetAward();
    }
}

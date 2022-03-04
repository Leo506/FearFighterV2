using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardController : MonoBehaviour
{
    [SerializeField] int moneyForVictory;  // Кол-во денег за победу
    [SerializeField] int moneyForFailed;   // Кол-во денег за проигрыш

    [SerializeField] int expForVictory;    // Кол-во опыта за победу
    [SerializeField] int expForFailed;     // Кол-во опыта за проигрыщ

    [SerializeField] float multiplier;     // Множитель, регулирующий величину награды


    private static int moneyAward;
    private static int expAward;

    System.Action onVictory;  // Делегат с функцией получения награды в случае победы
    System.Action  onFailed;  // Делегат с функцией получения награды в случае проигрыша

    private void Awake() 
    {
        onVictory = () => { SetAndGetAward(true); };
        onFailed = () => { SetAndGetAward(false); };
        
        PlayerLogic.PlayerDiedEvent += onFailed;
        
        BossFightPhase2.Boss.BossDiedEvent += onVictory;
    }

    private void OnDestroy() 
    {
        PlayerLogic.PlayerDiedEvent -= onFailed;
        
        BossFightPhase2.Boss.BossDiedEvent -= onVictory;
    }


    private void SetAndGetAward(bool isVictory)
    {
        moneyAward = (int)((isVictory ? moneyForVictory : moneyForFailed) * multiplier) + InventoryController.instance.GetItemNumber("MoneyItem");
        expAward = (int)((isVictory ? expForVictory : expForFailed) * multiplier);
        MoneyController.Money += moneyAward;
        ExpController.Exp += expAward;

        Debug.Log("Получена награда: " + moneyAward);
    }


    /// <summary>
    /// Возвращает кол-во денег, полученное в качестве награды
    /// </summary>
    /// <returns>Кол-во денег</returns>
    public static int GetMoneyAward()
    {
        return moneyAward;
    }


    /// <summary>
    /// Возвращет кол-во опыта, полученное, в качестве награды
    /// </summary>
    /// <returns>Кол-во опыта</returns>
    public static int GetExpAward()
    {
        return expAward;
    }
}

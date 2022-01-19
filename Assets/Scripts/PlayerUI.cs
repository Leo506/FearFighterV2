using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour, ISetUpObj
{
    [SerializeField] UnityEngine.UI.Slider playerHPSlider;
    [SerializeField] UnityEngine.UI.Button usingControllerJoystic;
    [SerializeField] UnityEngine.UI.Button attackControllerJoystic;


    public void SetUp() 
    {
    	playerHPSlider.maxValue = PlayerLogic.instance.maxHP;
    }


    public void ShowCurrentHp(float value) 
    {
    	playerHPSlider.value = value;
        Debug.Log("Current hp: " + value);
    }


    /// <summary>
    /// Изменяет контроллер игрока с атакующего на использования и наоборот)
    /// </summary>
    public void ChangePlayerController()
    {
        Debug.Log("Change controllers!");
        usingControllerJoystic.gameObject.SetActive(!usingControllerJoystic.gameObject.activeSelf);
        attackControllerJoystic.gameObject.SetActive(!attackControllerJoystic.gameObject.activeSelf);
    }
}

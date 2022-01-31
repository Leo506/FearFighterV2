using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour, ISetUpObj
{
    [SerializeField] Slider playerHPSlider;
    //[SerializeField] Button usingControllerJoystic;
    [SerializeField] GameObject attackControllerJoystic;
    [SerializeField] GameObject movementController;


    public void SetUp() 
    {
    	playerHPSlider.maxValue = PlayerLogic.instance.maxHP;

        GameController.Pause += EnablePlayerInputUI;
        GameController.Unpause += EnablePlayerInputUI;
    }


    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        GameController.Pause -= EnablePlayerInputUI;
        GameController.Unpause -= EnablePlayerInputUI;
    }


    /// <summary>
    /// Включает или выключает пользовательский интерфейс ввода в зависимости от значения параметра
    /// </summary>
    /// <param name="enable">Включить - true, выключить - false</param>
    void EnablePlayerInputUI()
    {
        attackControllerJoystic.SetActive(!attackControllerJoystic.activeSelf);
        movementController.SetActive(!movementController.activeSelf);
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
        // Debug.Log("Change controllers!");
        // usingControllerJoystic.gameObject.SetActive(!usingControllerJoystic.gameObject.activeSelf);
        // attackControllerJoystic.gameObject.SetActive(!attackControllerJoystic.gameObject.activeSelf);
    }
}

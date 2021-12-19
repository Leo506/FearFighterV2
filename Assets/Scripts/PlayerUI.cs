using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour, ISetUpObj
{
    [SerializeField] UnityEngine.UI.Slider playerHPSlider;


    public void SetUp() 
    {
    	playerHPSlider.maxValue = PlayerLogic.instance.maxHP;
    }


    public void ShowCurrentHp(float value) 
    {
    	playerHPSlider.value = value;
        Debug.Log("Current hp: " + value);
    }
}

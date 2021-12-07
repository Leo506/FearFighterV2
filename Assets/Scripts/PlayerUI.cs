using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour, ISetUpObj
{
    [SerializeField] UnityEngine.UI.Slider playerHPSlider;


    public void SetUp() 
    {
    	playerHPSlider.maxValue = GetComponent<PlayerLogic>().maxHP;
    }


    public void ShowCurrentHp() 
    {
    	playerHPSlider.value = PlayerLogic.currentHP;
    }
}

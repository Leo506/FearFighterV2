using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] Text moneyCountText, expCountText;

    private void Start() 
    {
        UpdateUI();   
    }

    private void UpdateUI()
    {
        moneyCountText.text = MoneyController.Money.ToString();
        expCountText.text = ExpController.Exp.ToString();
    }
}

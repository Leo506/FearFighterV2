using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] Text moneyCountText, expCountText;

    private void Awake() 
    {
        MoneyController.MoneyChanged += UpdateUI;
        ExpController.ExpChanged += UpdateUI;   
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        MoneyController.MoneyChanged -= UpdateUI;
        ExpController.ExpChanged -= UpdateUI;   
    }

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

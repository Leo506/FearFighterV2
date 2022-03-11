using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestProgress : MonoBehaviour
{
    [SerializeField] Text text;


    private void Start() 
    {
        text.text = ProgressSystem.GetInstance().currentStats.ToString();
    }

    public void AddItem()
    {
        ProgressSystem.GetInstance().inventory.AddItem(new EmptyItem(null, null, ""));
    }

    public void Recalculate()
    {
        ProgressSystem.GetInstance().CalculateStats();
        text.text = ProgressSystem.GetInstance().currentStats.ToString();
    }
}
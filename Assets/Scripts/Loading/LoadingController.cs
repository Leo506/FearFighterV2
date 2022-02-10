using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingController : MonoBehaviour
{
    private void Awake()
    {
        Generator.MapReadyEvent += () => SceneManager.LoadScene("SampleScene");
    }

    private void OnDestroy()
    {
        Generator.MapReadyEvent -= () => SceneManager.LoadScene("SampleScene");
    }
}

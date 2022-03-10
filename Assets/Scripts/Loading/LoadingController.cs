using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingController : MonoBehaviour
{
    private void Awake()
    {
        Loading.Generator.MapReadyEvent += () => SceneManager.LoadScene("SampleScene");
    }

    private void OnDestroy()
    {
        Loading.Generator.MapReadyEvent -= () => SceneManager.LoadScene("SampleScene");
    }
}

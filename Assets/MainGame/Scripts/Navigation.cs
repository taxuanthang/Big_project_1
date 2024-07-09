using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public static Navigation instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NavigationMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void NavigationMiniGameScene()
    {
        SceneManager.LoadScene("Minigame",LoadSceneMode.Additive);
    }
    public void NavigationEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}

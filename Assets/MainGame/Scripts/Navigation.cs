using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void NavigationMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}

using System;
using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuButtonEventHandler : MonoBehaviour
{

    public void ChangeScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

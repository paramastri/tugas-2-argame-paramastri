using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CheckWinner : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadSceneAsync("LevelWinner");
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadSceneAsync("EndGame");
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Vuforia;

public class MenuController : MonoBehaviour, IVirtualButtonEventHandler
{
    private VideoPlaybackBehaviour _videoPlaybackBehaviour;
    private bool _loadingScene = false;

    // Use this for initialization
    void Start()
    {
        VirtualButtonBehaviour[] buttonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
        foreach (var buttonBehaviour in buttonBehaviours)
        {
            if (buttonBehaviour)
            {
                buttonBehaviour.RegisterEventHandler(this);
            }
        }
        _videoPlaybackBehaviour = GetComponentInChildren<VideoPlaybackBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        if (vb.VirtualButtonName == "next_level")
        {
            if (!_loadingScene)
            {
                _loadingScene = true;
                SceneManager.LoadScene("Level2");
            }
        }
        else if (vb.VirtualButtonName == "main_menu")
        {
            if (!_loadingScene)
            {
                _loadingScene = true;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
    }
}

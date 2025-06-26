using System;
using UnityEngine;

public class PauseMultiplayerUI : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.OnMultiplayerGamePaused += GameManager_OnLocalGamePaused;
        GameManager.Instance.OnMultiplayerGameUnPaused += GameManager_OnLocalGameUnpaused;

        if (gameObject.activeInHierarchy)
        {
            Hide();
        }
    }
    
    private void GameManager_OnLocalGamePaused(object sender, EventArgs e)
    {
        Show();
    }

    private void GameManager_OnLocalGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

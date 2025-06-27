using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HostDisconnectUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;

    private void Awake()
    {
        playAgainButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        NetworkManager.Singleton.OnConnectionEvent += NetworkManager_OnConnectionEvent;

        if (gameObject.activeInHierarchy)
        {
            Hide();
        }
    }

    private void NetworkManager_OnConnectionEvent(NetworkManager manager, ConnectionEventData data)
    {
        if (NetworkManager.Singleton.IsHost) return;

        if (data.EventType == ConnectionEvent.ClientDisconnected)
        {
            Show();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        NetworkManager.Singleton.OnConnectionEvent -= NetworkManager_OnConnectionEvent;
    }
}


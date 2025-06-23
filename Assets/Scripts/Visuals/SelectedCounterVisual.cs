using System;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void Start()
    {
        if (Player.LocalInstance != null)
        {
            Player.LocalInstance.OnSelectCounterChanged += Player_OnSelectCounterChanged;
        }
        else
        {
            Player.OnAnyPlayerSpawned += Player_OnAnyPlayerSpawned;
        }
    }

    private void Player_OnAnyPlayerSpawned(object sender, EventArgs e)
    {
        if (Player.LocalInstance != null)
        {
            Player.LocalInstance.OnSelectCounterChanged -= Player_OnSelectCounterChanged;
            Player.LocalInstance.OnSelectCounterChanged += Player_OnSelectCounterChanged;
        }
    }

    private void Player_OnSelectCounterChanged(object sender, Player.OnSelectCounterChangedEventArgs e)
    {
        bool isSelectedCounter = e.selectedCounter == baseCounter;

        foreach (GameObject visualObject in visualGameObjectArray)
        {
            visualObject.SetActive(isSelectedCounter);
        }
    }
}

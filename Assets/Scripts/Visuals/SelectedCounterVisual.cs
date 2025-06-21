using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void Start()
    {
        Player.Instance.OnSelectCounterChanged += Player_OnSelectCounterChanged;
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

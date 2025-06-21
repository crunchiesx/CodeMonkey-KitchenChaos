using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player player;
    private float footSetTimer;
    private float footSetTimerMax = .1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        footSetTimer -= Time.deltaTime;
        if (footSetTimer <= 0f)
        {
            footSetTimer = footSetTimerMax;

            if (player.IsWalking())
            {
                float volume = 1f;
                SoundManager.Instance.PlayFootStepSound(player.transform.position, volume);
            }
        }
    }
}

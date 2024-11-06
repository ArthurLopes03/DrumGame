using UnityEngine;

public class BeatIcon : MonoBehaviour
{
    public PlayerRythmManager rythmManager;
    public void DestroyThis()
    {
        rythmManager.beatsIconCounter++;
        Destroy(gameObject);
    }
}
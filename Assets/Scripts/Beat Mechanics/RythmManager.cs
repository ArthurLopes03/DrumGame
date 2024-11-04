using UnityEngine;
using System.Collections.Generic;

public class RythmManager : MonoBehaviour
{
    public float timer = 0f;

    public List<Beat> beats;
    public List<GameObject> beatIcons;

    public bool P1isRecording = true;
    public bool P2isRecording = false;

    public bool P2isPlaying = false;
    public bool P1isPlaying = false;

    public GameObject P1beatPrefab;
    public GameObject P2beatPrefab;

    public Transform spawnPoint;

    public int xPoint;

    int i = 0;
    int j = 0;

    private void Start()
    {
        beats = new List<Beat>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("LeftClick") && P1isRecording)
        {
            Beat beat = new Beat(true, timer);

            beats.Add(beat);
        }

        if(Input.GetButtonDown("LeftClick") && P2isPlaying)
        {
            try
            {
                GameObject beatIcon = beatIcons[j];
                Transform beatPos = beatIcon.GetComponent<Transform>();

                if (beatPos.position.x >= xPoint - 1.5 && beatPos.position.x <= xPoint + 1.5)
                {
                    Destroy(beatIcon);
                    j++;
                    Debug.Log("Great!");
                }
                else
                {
                    Destroy(beatIcon);
                    j++;
                    Debug.Log("Miss");
                }
            }
            catch
            {

            }
        }

        if (timer > 10f && P1isRecording)
        {
            P1isRecording = false;
            Debug.Log("Timer stoped at " + timer);

            timer = 0f;
            P2isPlaying = true;
        }

        if (P2isPlaying)
        {
            try
            {
                if (beats[i].time <= timer)
                {
                    GameObject newBeat = Instantiate(P1beatPrefab, spawnPoint);

                    beatIcons.Add(newBeat);

                    i++;
                }
            }
            catch
            {
                if(i > beats.Count)
                {
                    P2isPlaying = false;
                }
            }
        }
    }
}

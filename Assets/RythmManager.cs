using UnityEngine;
using System.Collections.Generic;

public class RythmManager : MonoBehaviour
{
    public float timer = 0f;

    public List<Beat> beats;
    public List<GameObject> beatIcons;

    public bool isRecording = true;

    public bool isPlaying = false;

    public GameObject beatPrefab;

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

        if (Input.GetButtonDown("LeftClick") && isRecording)
        {
            Beat beat = new Beat(true, timer);

            beats.Add(beat);
        }

        if(Input.GetButtonDown("LeftClick") && isPlaying)
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

        if (timer > 10f && isRecording)
        {
            isRecording = false;
            Debug.Log("Timer stoped at " + timer);

            timer = 0f;
            isPlaying = true;
        }

        if (isPlaying)
        {
            try
            {
                if (beats[i].time <= timer)
                {
                    GameObject newBeat = Instantiate(beatPrefab, spawnPoint);

                    beatIcons.Add(newBeat);

                    i++;
                }
            }
            catch
            {
                if(i > beats.Count)
                {
                    isPlaying = false;
                }
            }
        }
    }
}

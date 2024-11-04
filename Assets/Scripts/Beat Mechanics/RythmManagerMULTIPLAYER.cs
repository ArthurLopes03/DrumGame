using UnityEngine;
using System.Collections.Generic;

public class RythmManagerMULTIPLAYER : MonoBehaviour
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
    public Transform strikePoint;

    public int xPoint;

    int i = 0;
    int j = 0;

    private void Start()
    {
        beats = new List<Beat>();
    }

    private void ClearAll()
    {
        beats.Clear();
        beatIcons.Clear();
        timer = 0;
        j = 0;
    }

    private void ClearTimer()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("LeftClick") && P1isRecording)
        {
            Beat beat = new Beat(true, timer);

            //beats.Clear();
            beats.Add(beat);
        }

        if (Input.GetButtonDown("RightClick") && P2isRecording)
        {
            Beat beat = new Beat(true, timer);

            //beats.Clear();
            beats.Add(beat);
        }

        if (Input.GetButtonDown("RightClick") && P2isPlaying)
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
        
        if (Input.GetButtonDown("LeftClick") && P1isPlaying)
        {
            GameObject beatIcon = beatIcons[j];
            Transform beatPos = beatIcon.GetComponent<Transform>();

            if (strikePoint.position.x >= xPoint - 1.5 && beatPos.position.x <= xPoint + 1.5)
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

        if (timer > 10f && P1isRecording)
        {
            P1isRecording = false;
            Debug.Log("Timer stoped at " + timer);

            ClearTimer();
            P2isPlaying = true;
        }

        if (timer > 10f && P2isRecording)
        {
            P2isRecording = false;
            Debug.Log("Timer stoped at " + timer);

            ClearTimer();
            P1isPlaying = true;
        }

        if (P2isPlaying)
        {
            try
            {
                if (beats[i].time <= timer)
                {
                    GameObject newBeat = Instantiate(P2beatPrefab, spawnPoint);

                    beatIcons.Add(newBeat);

                    i++;
                }
            }
            catch
            {
                if (i > beats.Count)
                {
                    i = 0;
                }
            }

            if(timer >= 15f)
            {
                P2isPlaying = false;
                P2isRecording = true;
                ClearAll();
            }
        }

        if (P1isPlaying)
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
                if (i > beats.Count)
                {
                    i = 0;
                }
            }

            if (timer >= 15f)
            {
                P1isPlaying = false;
                P1isRecording = true;
                ClearAll();
            }
        }
    }
}

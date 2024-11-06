using UnityEngine;
using System.Collections.Generic;

public class PlayerRythmManager : MonoBehaviour
{
    public GameManager gameManager;
    public string inputA;
    public string inputB;

    public float timer = 0f;

    public List<Beat> beats;
    public List<GameObject> beatIcons;

    public bool isRecording = true;
    public bool isPlaying = false;

    public GameObject beatPrefab;
    public Transform spawnPoint;

    public int xPoint;

    public int beatsCounter = 0;
    public int j = 0;

    private void Start()
    {
        beats = new List<Beat>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        //-----RECORDING-----
        if (Input.GetButtonDown(inputA) && isRecording)
        {

            Beat beat = new Beat(true, timer);

            beats.Add(beat);
        }

        if (timer > 5f && isRecording)
        {
            isRecording = false;

            timer = 0f;

            gameManager.NextRound(beats);

            beats.Clear();
        }


        //-----PLAYING-----
        if (Input.GetButtonDown(inputA) && isPlaying)
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

        if (isPlaying)
        {
            try {
                if (beats[beatsCounter].time <= timer)
                {
                    Debug.Log("Spawn");

                    GameObject newBeat = Instantiate(beatPrefab, spawnPoint);

                    beatIcons.Add(newBeat);

                    beatsCounter++;
                }
            }
            catch 
            {
                Debug.Log("Round Over");
                isPlaying = false;
                Invoke("StartRound", 5);
            }

        }
    }

    public void StartRound()
    {
        Debug.Log("New round started");
        timer = 0f;
        isRecording = true;
    }
}

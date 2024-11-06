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
    public int beatsIconCounter = 0;

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
            beatsCounter = 0;
            beatsIconCounter = 0;

            isRecording = false;

            timer = 0f;

            gameManager.NextRound(beats);

            beats.Clear();
        }


        //-----PLAYING-----
        if (Input.GetButtonDown(inputA) && isPlaying)
        {

            if (beatsIconCounter < beatIcons.Count)
            {
                GameObject beatIcon = beatIcons[beatsIconCounter];
                Transform beatPos = beatIcon.GetComponent<Transform>();
                if (beatIcon != null)
                {
                    if (beatPos.position.x >= xPoint - 1.5 && beatPos.position.x <= xPoint + 1.5)
                    {
                        Destroy(beatIcon);
                        beatsIconCounter++;
                        //Debug.Log("Great!");
                    }
                    else
                    {
                        Destroy(beatIcon);
                        beatsIconCounter++;
                        //Debug.Log("Miss");
                    }
                }
            }
        }

        if (isPlaying)
        {
            if (beatsCounter < beats.Count)
            {
                if (beats[beatsCounter].time <= timer)
                {
                    GameObject newBeat = Instantiate(beatPrefab, spawnPoint);
                    newBeat.GetComponent<BeatIcon>().rythmManager = this;
                    beatIcons.Add(newBeat);

                    beatsCounter++;
                }
            }
            else if (beatsCounter == beats.Count)
            {
                Invoke("StartRound", 3f);
                beatsCounter++;
            }
        }
    }

    public void StartRound()
    {
        isPlaying = false;
        Debug.Log("Start Round");
        beatIcons.Clear();
        timer = 0f;
        isRecording = true;
    }
}

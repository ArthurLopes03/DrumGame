using UnityEngine;
using System.Collections.Generic;

public class RythmManager : MonoBehaviour
{
    public float timer = 0f;

    public List<Beat> beats;

    public bool isRecording = true;

    public GameObject beatPrefab;

    private void Start()
    {
        beats = new List<Beat>();
    }

    private void Update()
    {
        if(isRecording)
            timer += Time.deltaTime;

        if (Input.GetButtonDown("LeftClick") && isRecording)
        {
            Beat beat = new Beat(true, timer);

            beats.Add(beat);
        }

        if (timer > 10f)
        {
            isRecording = false;
            Debug.Log("Timer stoped at " + timer);

            timer = 0f;

            GoThroughBeats();
        }
    }

    void GoThroughBeats()
    {
        foreach (Beat beat in beats)
        {
            Debug.Log("Time: " + beat.time);
            GameObject beatObj = Instantiate(beatPrefab);

            Vector3 newPosition = new Vector3(beat.time - 10, 0, 0);

            beatObj.transform.position += newPosition;
        }
    }
}

using UnityEngine;

public class BeatIcon : MonoBehaviour
{
    public float moveSpeed = 1f;
    bool moving = true;
    public float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (true)
        {
            Vector3 newPos = new Vector3(moveSpeed * Time.deltaTime, 0, 0);

            transform.position += newPos;
        }

        if (transform.position.x >= 10 && moving)
        {
            Debug.Log(timer - moveSpeed);
            moving = false;
        }
    }
}
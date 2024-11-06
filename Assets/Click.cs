using UnityEngine;

public class Click : MonoBehaviour
{
    public string inputA;
    public string inputB;

    private void Update()
    {
        if (Input.GetButtonDown(inputA))
        {
            Debug.Log("Click!");
        }
        else if (Input.GetButtonDown(inputB))
        {
            Debug.Log("Clack!");
        }
    }
}

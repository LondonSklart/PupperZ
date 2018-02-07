using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Light lt;

    // Use this for initialization
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.O))
        {
            transform.Translate(0, -Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.N))
        {
            MakeNight();
        }
        if (Input.GetKey(KeyCode.M))
        {
            MakeDay();
        }

    }
    public void MakeNight()
    {
        lt.intensity = 0.0f;
    }
    public void MakeDay()
    {
        lt.intensity = 1.0f;
    }
}
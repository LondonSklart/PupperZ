using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public AudioSource BarkSound, GrowlSound, PeeSound, ThemeTune;

    // Use this for initialization
    void Start () {
        ThemeTune.Play();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.B))
        {
            BarkSound.Play();
        }
        if (Input.GetKey(KeyCode.G))
        {
            GrowlSound.Play();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            PeeSound.Play();
        }

    }
}

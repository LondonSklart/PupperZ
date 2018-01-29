using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{

    Playercontroller player;
    Vector3 playerLocation;
    Vector3 cameraOffset;
    // Use this for initialization
    void Start ()
    {
       player = FindObjectOfType<Playercontroller>();
        cameraOffset = gameObject.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {

         playerLocation = player.transform.position;
        playerLocation += cameraOffset;
        gameObject.transform.position = playerLocation;
	}
}

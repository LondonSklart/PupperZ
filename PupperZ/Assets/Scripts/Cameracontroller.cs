using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{

    Playercontroller player;
    Vector3 playerLocation;
    Vector3 cameraOffset;

    public GameObject cam1, cam2;
    // Use this for initialization
    void Start ()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);

       player = FindObjectOfType<Playercontroller>();
        cameraOffset = gameObject.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player != null)
        {


            playerLocation = player.transform.position;
            playerLocation += cameraOffset;
            gameObject.transform.position = playerLocation;
        }

        if (Input.GetKey(KeyCode.C))
        {
            NeckCamera();
        }
        if (Input.GetKey(KeyCode.X))
        {
            OverHeadCamera();
        }
    }

    public void NeckCamera()
    {
        cam2.SetActive(true);
        cam1.SetActive(false);
        
    }
    public void OverHeadCamera()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }
}

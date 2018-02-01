using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisscontroller : MonoBehaviour
{
    private float pissDuration = 5;


    private void Update()
    {
		pissDuration -= Time.deltaTime;
        if (pissDuration < 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        collision.gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;


        Destroy(gameObject);
        
    }


}

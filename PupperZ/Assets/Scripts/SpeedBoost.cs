using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    Playercontroller player;

    private void Start()
    {
        player = FindObjectOfType<Playercontroller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PupperZ")
        {
            player.speed = 20;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(Timer());
        }
    }
    

    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        player.speed = 10;
        Destroy(gameObject);


    }

}

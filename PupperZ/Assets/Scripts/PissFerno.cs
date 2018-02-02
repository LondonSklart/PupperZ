using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissFerno : MonoBehaviour
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
            player.SetPissFerno(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(Timer());
        }
    }



    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        player.SetPissFerno(false);
        Destroy(gameObject);


    }
}

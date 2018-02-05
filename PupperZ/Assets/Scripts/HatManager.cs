using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    GameObject hatLocation;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PupperZ")
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            hatLocation = GameObject.FindGameObjectWithTag("Hatlocation");
            Instantiate(gameObject, hatLocation.transform);
            Destroy(gameObject);

        }
    }

}

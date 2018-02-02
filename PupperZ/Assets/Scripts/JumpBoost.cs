using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour {

    Playercontroller player;

    private void Start()
    {
        player = FindObjectOfType<Playercontroller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PupperZ")
        {
            player.SetJump();
            Destroy(gameObject);
        }
    }
}

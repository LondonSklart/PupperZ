using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisscontroller : MonoBehaviour
{
    private float pissDuration = 5;

    GameManager1 game;

    private void Start()
    {
        game = FindObjectOfType<GameManager1>();
    }

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
        if (collision.transform.tag == "Hydrant")
        {
            game.Score();
            if (game.GetScore() == 1)
            {
                game.Victory();
            }
        }

        Destroy(gameObject);
        
    }


}

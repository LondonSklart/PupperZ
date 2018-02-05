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

        if (collision.transform.tag == "Hydrant")
        {
            game.PissAmount();
            if (game.GetPissAmount() > 10)
            {
            collision.gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;

            game.Score();
            collision.transform.tag = "Done";
                game.ResetPiss();
            }
            

            

            if (game.GetScore() == 10)
            {
                game.Victory();
            }
        }

        Destroy(gameObject);
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    int score = 0;


    public void Victory()
    {
        Debug.Log("Win");
    }
    public void Score()
    {
        score++;
    }
    public int GetScore()
    {
        return score;
    }

}

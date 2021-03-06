﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    int score = 0;
    int pissAmount;

    public GameObject[] hydrants;

    private void Start()
    {
        hydrants = GameObject.FindGameObjectsWithTag("Hydrant");
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Victory()
    {
        SceneManager.LoadScene("WinScreen");
    }
    public void Score()
    {
        score++;
    }
    public int GetScore()
    {
        return score;
    }
    public void PissAmount()
    {
        pissAmount++;
    }
    public  int GetPissAmount()
    {
        return pissAmount;
    }
    public void ResetPiss()
    {
        pissAmount = 0;
    }
    
}

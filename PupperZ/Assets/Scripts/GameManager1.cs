using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    int score = 0;
    int pissAmount;

    public GameObject[] hydrants;
    
    public AudioSource ThemeTune;

    private void Start()
    {
        hydrants = GameObject.FindGameObjectsWithTag("Hydrant");
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayDelayed(0.5f);
        audio.loop = true;
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

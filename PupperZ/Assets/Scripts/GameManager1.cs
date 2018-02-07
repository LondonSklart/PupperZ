using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    int score = 0;
    int pissAmount;

    public GameObject[] hydrants;
    public GameObject cam1, cam2;

    private void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);

        hydrants = GameObject.FindGameObjectsWithTag("Hydrant");
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            NeckCamera();
        }
        if (Input.GetKey(KeyCode.X))
        {
            OverHeadCamera();
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

    public void NeckCamera()
    {
        cam2.SetActive(true);
        cam1.SetActive(false);
        
    }
    public void OverHeadCamera()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }
}

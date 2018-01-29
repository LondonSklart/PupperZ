using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardControlelr : MonoBehaviour {

    public float speed = 10;
    private int checkPointIndex = 0;

    public GameObject[] checkpoints;

    Vector3 currentCheckPoint;

    // Use this for initialization
    void Start ()
    {
        currentCheckPoint = checkpoints[checkPointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
    
        if (Physics.Raycast(gameObject.transform.position,currentCheckPoint,2.5f)== false)
        {
        WalkForward();
        }

		
	}

    public void WalkForward()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,currentCheckPoint,speed*Time.deltaTime);
        Vector3 targetDir = currentCheckPoint - gameObject.transform.position;
        Vector3 newDir = Vector3.RotateTowards(gameObject.transform.forward, targetDir, 1, 0.0F);
        gameObject.transform.rotation = Quaternion.LookRotation(newDir);
        Debug.DrawRay(gameObject.transform.position,newDir,Color.blue);
        //transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(currentCheckPoint),0.5f);
        if (gameObject.transform.position == currentCheckPoint)
        {
            NextCheckPoint();
        }
    }
    public void NextCheckPoint()
    {
        if (checkPointIndex-1 == checkpoints.Length)
        {
            checkPointIndex = 0;
        }
        else
        {
         checkPointIndex++;
        }
       
        currentCheckPoint = checkpoints[checkPointIndex].transform.position;
    }
}

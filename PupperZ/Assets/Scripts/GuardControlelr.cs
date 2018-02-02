using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardControlelr : MonoBehaviour {

    public float speed = 10;
    private int checkPointIndex = 0;
    private bool trackingPupperZ = false;

    private float bufferTime = 1;

    public GameObject[] checkpoints;

    Vector3 currentCheckPoint;
    public GameObject pupperZ;
    NavMeshAgent agent;

    // Use this for initialization
    void Start ()
    {
        currentCheckPoint = checkpoints[checkPointIndex].transform.position;
       agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(currentCheckPoint);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (trackingPupperZ == false)
        {
            ScanForPupperZ();
        }
        if (trackingPupperZ == true)
        {
            if (pupperZ != null)
            {


                agent.SetDestination(pupperZ.transform.position);
                agent.speed = 12;
                bufferTime -= Time.deltaTime;
                if (agent.remainingDistance > 20 && bufferTime < 0)
                {
                    Debug.Log("Boom");
                    trackingPupperZ = false;
                    bufferTime = 1;
                    agent.speed = 3.5f;
                    NextCheckPoint();
                }
            }
        }
        if (agent.remainingDistance <= 1)
        {
            NextCheckPoint();
        }
 
        else if (Physics.Raycast(gameObject.transform.position, transform.forward, 5f) == true)
        {
           // gameObject.transform.Rotate(0, 2, 0);
        }
        Debug.DrawRay(gameObject.transform.position, new Vector3(0,0,5), Color.red);
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "PupperZ")
        {
            Destroy(collision.gameObject);
            agent.speed = 3.5f;
        }
    }

    public void WalkForward()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,currentCheckPoint,speed*Time.deltaTime);
        Vector3 targetDir = currentCheckPoint - gameObject.transform.position;
        Vector3 newDir = Vector3.RotateTowards(gameObject.transform.forward, targetDir, 1, 0.0F);
        gameObject.transform.rotation = Quaternion.LookRotation(newDir);
        if (gameObject.transform.position == currentCheckPoint)
        {
            NextCheckPoint();
        }
    }
    public void NextCheckPoint()
    {
        if (checkPointIndex+1 == checkpoints.Length)
        {
            checkPointIndex = 0;
        }
        else
        {
         checkPointIndex++;
        }
       
        currentCheckPoint = checkpoints[checkPointIndex].transform.position;
        agent.SetDestination(currentCheckPoint);

    }
    public void ScanForPupperZ()
    {
        Collider[] collider = Physics.OverlapSphere(gameObject.transform.position, 10);
        if (collider.Length > 0)
        {
            foreach (Collider col in collider)
            {
                if (col.tag == "PupperZ")
                {
                    agent.SetDestination(pupperZ.transform.position);
                    trackingPupperZ = true;
                }
            }
        }
    }
}

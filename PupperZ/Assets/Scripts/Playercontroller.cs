using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour {

	[SerializeField]
	private Stat pissOMeter;

	private void Awake()
	{
		pissOMeter.Initialize ();
	}
	public bool canPiss; 
    public float speed = 10;
    public float pissForce = 100;
	public GameObject piss;
    Animator[] animators;
    Rigidbody body;

    private void Start()
    {
       body = gameObject.GetComponent<Rigidbody>();
        animators = FindObjectsOfType<Animator>();
        foreach (Animator a in animators)
        {
            a.enabled = false;
        }

    }
    // Update is called once per frame
    void Update ()
    {
		if (canPiss == true)
		{
			FirePiss ();
		}
		canPiss = false;	

		if (Input.GetKey(KeyCode.Space))
		{
			canPiss = true;
		}
		if (Input.GetKey(KeyCode.Space))
		{
			pissOMeter.CurrentVal -= 1;
		}

		if (pissOMeter.CurrentVal < 0 ) 
		{
			canPiss = false;
		} 
		else if (pissOMeter.CurrentVal > 100) 
		{
			pissOMeter.CurrentVal = 100; 
		}

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            foreach (Animator a in animators)
            {
                a.enabled = true;
            }


            Vector3 movement = new Vector3(moveHorizontal, 0.0001f, moveVertical);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.J) && Physics.Raycast(gameObject.transform.position,Vector3.down,2.5f))
        {
            body.AddForce(0, 10, 0,ForceMode.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {


            foreach (Animator a in animators)
            {
                a.enabled = false;
            }
    }
	}

	public void FirePiss ()
	{
	GameObject clone;
	clone = Instantiate(piss,gameObject.transform.position,transform.rotation);
	clone.GetComponent<Rigidbody>().AddForce(gameObject.transform.right*pissForce);
	}
}

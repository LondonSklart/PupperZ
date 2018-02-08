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
	private bool canPiss;
    private bool isPissing;
    private bool canJump = false;
    private bool pissFerno = false;
	public float speed = 10;
	public float pissForce = 100;
    public float jumpHeight = 10;
	public GameObject piss;
    Animator animator;
	Rigidbody body;

	private void Start()
	{
		body = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        animator.speed = 10;

	}
	// Update is called once per frame
	void Update ()
	{
		if (canPiss == true)
		{
            if (pissFerno)
            {
                PissFerno();

            }
            else
            {
                FirePiss();

            }
        }
		canPiss = false;	

		if (Input.GetKey(KeyCode.Space))
		{
			canPiss = true;
            pissOMeter.CurrentVal -= 1;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isPissing = false;
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
            animator.Play("walking");

            if (isPissing == false)
            {
                Vector3 movement = new Vector3(moveHorizontal, 0.0001f, moveVertical);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
                transform.Translate(movement * speed * Time.deltaTime, Space.World);
            }

		}
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            animator.Play("Idle");
        }
            if (Input.GetKeyDown(KeyCode.J) && Physics.Raycast(gameObject.transform.position,Vector3.down,0.5f) && canJump == true)
		{
			body.AddForce(0, jumpHeight, 0,ForceMode.Impulse);
            canJump = false;
		}

		
	}

	public void FirePiss ()
	{
		GameObject clone;
		clone = Instantiate(piss,gameObject.transform.position,transform.rotation);
		clone.GetComponent<Rigidbody>().AddForce(gameObject.transform.right*pissForce);
        isPissing = true;

    }
    public void PissFerno()
    {
        int x =  Random.Range(1, 5);
        Vector3 rotation = gameObject.transform.position;
        switch (x)
        {
            case 1:
                rotation = gameObject.transform.forward;
                break;
            case 2:
                rotation = gameObject.transform.right;
                break;
            case 3:
                rotation = -gameObject.transform.forward;
                break;
            case 4:
                rotation = -gameObject.transform.right;

                break;
        }

        Debug.Log(gameObject.transform.right);

        GameObject clone;
        clone = Instantiate(piss, gameObject.transform.position, transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(rotation * pissForce);
    }
    public void SetJump()
    {
        canJump = true;
    }
    public void SetPissFerno(bool bom)
    {
        if (bom == true)
        {
            pissFerno = true;
        }
        else
        {
            pissFerno = false;
        }

    }
}
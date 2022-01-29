using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	private GameObject currentTeleporter;

	public float runSpeed = 0f;
	public float playerHealth = 0f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;


    private void Awake()
    {
		PlayerPrefs.DeleteAll(); 
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		transform.Translate(Vector2.right * Time.deltaTime*10f);//forcemoving player to the right.

		if (Input.GetButtonDown("Jump"))//player jumps
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))//player crouches
		{
			crouch = true;
			Debug.Log("Crouch");
		} 
		else if (Input.GetButtonUp("Crouch"))//defaults to not crouched.
		{
			crouch = false;
			Debug.Log("NotCrouch");
		}
		if(currentTeleporter != null)
        {
			transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;//takes position and changes it to the designated TP in Unity.
        }

	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
			currentTeleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
			if(collision.gameObject == currentTeleporter)//changes variable of which tp to the one specified.
            {
				currentTeleporter = null;
            }
        }
    }
}
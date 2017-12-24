using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public GameObject stratPos;
    private Rigidbody rb;
    public float jumpForce;
    private bool isJumping;
    private bool ropeCreated;
    private float previousYVelocity;

    public float groundHeight;
    public float jumpHeight;

    public GameObject ropeEnd;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb.velocity.y);
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(0, 0, -moveSpeed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(0, 0, moveSpeed) * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*jumpForce);
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Destroy(gameObject.GetComponent<FixedJoint>());
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            
        }


        Debug.Log(rb.velocity.y);
        if (transform.position.y-groundHeight >= jumpHeight && isJumping && !ropeCreated)
        {
            FindObjectOfType<RopeGenerator>().generateRope(stratPos, transform.position);
            ropeCreated = true;
        }
        previousYVelocity = rb.velocity.y;
    }
}

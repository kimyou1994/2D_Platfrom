using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float jumpDist = 400f;

    private bool isFlipped;
    private Rigidbody playerRB;
    private SpriteRenderer rend;
    private Animator anim;
    private bool isGrounded;
    private bool isButtonPressed;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            playerRB.AddForce(Vector3.up * jumpDist);
            isGrounded = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");

        playerRB.velocity = new Vector3(move * speed, playerRB.velocity.y);

        if (move < 0) {
            isFlipped = true;
        }else if(move > 0) {
            isFlipped = false;
        }

        if (move != 0) {
            anim.SetBool("isWalking", true);
        }else {
            anim.SetBool("isWalking", false);
        }

        if (isGrounded == false) {
            anim.SetBool("hasJumped", true);
        }else {
            anim.SetBool("hasJumped", false);
        }

        Flip();
	}

    void Flip() {
        if (!isFlipped) {
            rend.flipX = false;
        }else {
            rend.flipX = true;
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "button") {
            isGrounded = true;
        }
    }
}

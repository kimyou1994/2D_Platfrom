using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {

    private Animator anim;

    private bool isPressed;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       // print(anim.GetBool("isPressed"));
        if (isPressed) {
            anim.SetBool("isPressed", true);
        } else {
            anim.SetBool("isPressed", false);
           // print("button unpressed");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            isPressed = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            isPressed = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawAI : MonoBehaviour {

    public Transform leftEdge, rightEdge;

    public Rigidbody mainBody;

    public float moveSpeed = 0.01f;
    public float stopTime = 1;
    private float move;
    private bool isStopped, isRight;
    private float timer;
	// Use this for initialization
	void Start () {
        mainBody = GetComponentInParent<Rigidbody>();
	}

    // Update is called once per frame
    void fixedUpdate()
    {
        if (isStopped)
        {
            move = 0;
            timer += Time.deltaTime;
            if (timer >= stopTime)
            {
                isStopped = false;
                timer = 0;
            }
        }
        else
        {
            if (!isRight)
            {
                move = moveSpeed;
            }
            else
            {
                move = -moveSpeed;
            }
        }

        mainBody.MovePosition(mainBody.position + Vector3.left * move);
        RaycastHit2D hitLeft = Physics2D.Raycast(leftEdge.position, Vector2.down, 0.5f);
        RaycastHit2D hitRight = Physics2D.Raycast(rightEdge.position, Vector2.down, 0.5f);
        if (!isRight)
        {
            if (hitLeft.collider == null)
            {
                isStopped = true;
                isRight = true;
            }
        }
        if (isRight)
        {
            if (hitRight.collider == null)
            {
                isStopped = true;
                isRight = false;
            }
        }
    }
}

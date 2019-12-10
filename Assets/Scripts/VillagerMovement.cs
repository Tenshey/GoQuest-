using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D myRigidBody;

    public float walkTime;

    public bool isWalking;

    public float waitTime;

    private float walkCounter;

    private float waitCounter;

    private int WalkDirection;

    public Collider2D walkZone;

    private bool hasWalkZone;

    public bool CanMove;

    private DialogueManager theDM;

	// Use this for initialization
	void Start () {



        myRigidBody = GetComponent<Rigidbody2D>();
        theDM = FindObjectOfType<DialogueManager>();
        //liczniki
        walkCounter = walkTime;
        waitCounter = waitTime;

        ChooseDirection();

        hasWalkZone = true;

        if(walkZone != null)
        {
            //wartosci dla obszaru do poruszania sie
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
        CanMove = true;
        
  	}
	
	// Update is called once per frame
	void Update () {


        //jesli nie ma interakcji moze sie ruszac dalej
        if(!theDM.dialogActive)
        {
            CanMove = true;
        }

        if (!CanMove)
        {
            myRigidBody.velocity = Vector2.zero;
            return;

        }

		if(isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch(WalkDirection)
            {
                case 0:
                    myRigidBody.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone && transform.position.y >= maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 1:
                    myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x >= maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 2:
                    myRigidBody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y <= minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 3:
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x <= minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;


            if(walkCounter <= 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidBody.velocity = Vector2.zero;

            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}

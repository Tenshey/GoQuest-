using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

    public float moveSpeed;
    public float moveInterval; //Time it takes between moves (timeBetweenMove).
    public float moveTime; //Time it takes to move (timeToMove).

    private Rigidbody2D enemyRigidBody;
    private bool isMoving; //Checks if the object is moving or not.
    private Vector3 moveDirection; //Determines the direction to move.

    private float moveIntervalCounter;
    private float moveTimeCounter; //Keeps the count for moveInterval and moveTime
    public  float waitToReload;
    private bool reloading;
    private GameObject thePlayer;

    // Use this for initialization
    void Start()
    {
        //moveIntervalCounter = moveInterval;
        //moveTimeCounter = moveTime;
        enemyRigidBody = GetComponent<Rigidbody2D>();

        moveIntervalCounter = Random.Range(moveInterval * 0.75f, moveInterval * 1.25f);
        moveTimeCounter = Random.Range(moveTime * 0.75f, moveInterval * 1.25f);

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            moveTimeCounter -= Time.deltaTime; // Ticks down the counter by Time.deltaTime.
            enemyRigidBody.velocity = moveDirection;

            if (moveTimeCounter < 0f)
            {
                //moveIntervalCounter = moveInterval; // Resetting moveIntervalCounter to default value.
                moveIntervalCounter = Random.Range(moveInterval * 0.75f, moveInterval * 1.25f);
                isMoving = false; // If no more time to move, movement is false.
                Debug.Log("Is Moving!");
            }

        }

        else
        {
            moveIntervalCounter -= Time.deltaTime; // Ticks down the counter by Time.deltaTime.
            enemyRigidBody.velocity = Vector2.zero; // If time has expired, reduces all velocity in all directions to zero.

            if (moveIntervalCounter < 0f)
            {
                //moveTimeCounter = moveTime; // Resetting moveTimeCounter to default value.
                moveTimeCounter = Random.Range(moveTime * 0.75f, moveInterval * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                isMoving = true;
                Debug.Log("IS Not Moving!");
            }

        }
        if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                // Application.loadedLevel(Application.loadedLevel);
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
                thePlayer.SetActive(true);
            }
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {   
         /*
        if(other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);

            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;

        } */
    }
        
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float digitonalMoveModifier;

    public float moveSpeed;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    private bool playerMoving;
    public Vector2 lastMove;
    private Vector2 moveInput;
    private static bool playerExists;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    public string startPoint;
    private float currentMoveSpeed;
    public bool canMove;
    private SFXManager sfxMan;

    //inicjacja
    void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>();
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        canMove = true;

        lastMove = new Vector2(0, -1f);

    }

    // Update is called once per frame
    void Update()
    {
        //sprawdzenie jak mocno sygnal wejscia zostal przeslany 
        //poziomo i pionowo
        playerMoving = false;
        if(!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }
        if (!attacking)
        {
            // sprawdzamy czy kliknal w prawo czy w lewo
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            // sprawdzamy czy kliknal w dol czy w gore
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);

            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }
            //normalizacja ruchu
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            //jesli sie rusza
            if(moveInput != Vector2.zero)
            {
                myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
                lastMove = moveInput;
            }
            else
            {
                myRigidbody.velocity = Vector2.zero;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);

                sfxMan.playerAttack.Play();
            }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}

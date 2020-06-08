using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool resetScore = false;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public int score;
    public static int count;
    public Text countText;


    void Start()
    {
    // allows player to jump more times in air
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        if (resetScore == true)
        {
            count = 0;
        }

        
    }


    void FixedUpdate()
    {
        //movement for the player
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    void Update()
    {
        //coding in order to jump
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;

        }
    }




    void Flip()
    {
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = !facingRight;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //pick up key
        if (other.tag == "Key")
        {
            score += 10;
            Destroy(other.gameObject);
        }
        //crystals add to score after collision with player
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        void SetCountText()
        {
            countText.text = "Score: " + count.ToString();
        }
    }

   
       
    

}

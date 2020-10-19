using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //config
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float climbSpeed;
    //cache
    Rigidbody2D rb;
    BoxCollider2D playerFoot;
    CircleCollider2D playerBody;
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerFoot = GetComponent<BoxCollider2D>();
        playerBody = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Run();
        Jump();
        ClimbLadder();
        FlippingSprite();
    }
    private void Run()
    {
        float inputHr = CrossPlatformInputManager.GetAxisRaw("Horizontal") * moveSpeed;
        Vector2 horizontalVector = new Vector2(inputHr, rb.velocity.y);
        rb.velocity = horizontalVector;

        bool running = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        anim.SetBool("isRunning", running);
        
    }

    private void Jump()
    {

        //jika kaki player tidak berada di ground

        if (!playerFoot.IsTouchingLayers(LayerMask.GetMask("Ground"))){ return; }   // maka player tidak dapat loncat


        // jika button ditekan
        if (CrossPlatformInputManager.GetButton("Jump"))
        {
            // set vector ke arah vertical & set jumpspeed
            Vector2 playerVelocityJump = new Vector2(rb.velocity.x, jumpForce);
            // aplikasikan kedalam physic player
            rb.velocity = playerVelocityJump;
        }
    }

    private void FlippingSprite()
    {
        // jika player bergerak x axis 
        bool playerIsMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerIsMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1);
        }
    }

    private void ClimbLadder()
    {
        //jika player tidak bertemu dengan tangga
        if (!playerBody.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            //controller tetap horizontal
            return;
        }

        //jika player collider bertemu dengan tangga
        if (playerBody.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            //memasukan controller menjadi vertical & memasukan kecepatan
            float inputVertical = CrossPlatformInputManager.GetAxisRaw("Vertical") * climbSpeed;
            //set posisi vertical 
            Vector2 verticalVelocity = new Vector2(rb.velocity.x, inputVertical);
            //aplikasikan kedalam physic
            rb.velocity = verticalVelocity;
        }
    }
}

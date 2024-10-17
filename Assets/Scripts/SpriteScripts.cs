using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScripts : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    bool isGrounded;
    bool isJumping;
    float speed;
    HelperTest helper;
    LayerMask groundLayerMask;
    int health;
    public GameObject Teleport;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<HelperTest>();
        speed = 4;
        groundLayerMask = LayerMask.GetMask("Ground");
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        SpriteMove();
        SpriteJump();
        SpriteFalling();
        SpriteLand();
        isGrounded = helper.ExtendedRayCollisionCheck(0, 0);
    }

    void SpriteMove()
    {

        anim.SetBool("walk", false);


        if (Input.GetKey("left") == true)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            anim.SetBool("walk", true);
            //   sr. flipX = true;
            helper.FlipObject(true);
        }
        else if (Input.GetKey("right") == true)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            anim.SetBool("walk", true);
            //  sr.flipX = false;
            helper.FlipObject(false);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    void SpriteJump()
    {
        if (Input.GetKeyDown("space") == true && isGrounded == true)
        {
            rb.AddForce(new Vector3(0, 8, 0), ForceMode2D.Impulse);
            anim.SetBool("jumping", true);

            isJumping = true;
        }
    }
    void SpriteFalling()
    {
        anim.SetBool("fall", false);

        if (isJumping && (rb.velocity.y < 0))
        {
            anim.SetBool("fall", true);
        }
        else if (rb.velocity.y <= 0 && isGrounded == false)
        {
            anim.SetBool("fall", true);
        }
    }

    void SpriteLand()
    {
        if (isJumping && (rb.velocity.y <= 0))
        {
            isJumping = false;
            anim.SetBool("fall", false);
            anim.SetBool("jumping", false);
        }
    }
    public void TakeDamage()
    {
        health--;
        if (health == 0)
        {
            gameObject.SetActive(false);
        }
    }
    public int GetHealth()
    {
        return health;
    }
    private void OnTriggerEnter2D ()
    {
        if (Input.GetKey("a"))
        {
            Player.transform.position = Teleport.transform.position;
        }
    }
}
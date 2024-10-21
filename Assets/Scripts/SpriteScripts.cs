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
    public int currentHealth;
    public int maxHealth = 3;
    public GameObject Teleport;
    public GameObject Player;
    public GameObject Portal;
    int flashCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<HelperTest>();
        speed = 4;
        groundLayerMask = LayerMask.GetMask("Ground");
        currentHealth = maxHealth;
        flashCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FlashPlayer();

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
        flashCounter = 2*60;
        currentHealth--;
        if (currentHealth == 0)
        {
            Player.transform.position = Teleport.transform.position;
            currentHealth = maxHealth;
            flashCounter = 0;
        }
    }
    public void EndPortal()
        {
            gameObject.SetActive(false);
        }
    public int GetHealth()
    {
        return currentHealth;
    }

    void FlashPlayer()
    {
        if( flashCounter > 0 )
        {
            flashCounter--;

            int res = (flashCounter/3) & 1;
            if( res==0 )
            {
                sr.color = Color.white;
            }
            else
            {
                sr.color = Color.red;
            }


        }
    }

}
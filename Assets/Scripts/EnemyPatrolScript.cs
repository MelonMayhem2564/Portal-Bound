using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour
{
    int enemyDir;
    float speed = 1.5f;
    LayerMask groundLayerMask;
    Rigidbody2D rb;
    HelperTest helper;
    DamagePlayer damageplayer;
    SpriteRenderer sr;
    float px, ex;

    //Start is called before the first frame update
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        helper = gameObject.AddComponent<HelperTest>(); 
        damageplayer = gameObject.AddComponent<DamagePlayer>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = new Vector2(speed, 0);
    }

    //Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {

        //check for enemy walking left and left side not touching a platform

        if (helper.ExtendedRayCollisionCheck(-0.5f, 0) == true)
        {
            if (rb.velocity.x < 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                helper.FlipObject(false);
            }
        }
        if (helper.ExtendedRayCollisionCheck(0.5f, 0) == true)
        {
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                helper.FlipObject(true);
            }
        }
    }
    
}

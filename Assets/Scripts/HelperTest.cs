using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperTest : MonoBehaviour
{
    LayerMask groundLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlipObject (bool flip)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.4f;
        bool hitSomething = false;
        bool isGrounded = false;
        Vector3 offset = new Vector3(xoffs, yoffs, 0);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position + offset, -Vector3.up, rayLength, groundLayerMask);
        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            print("Player has collided with ground layer");
            hitColor = Color.green;
            hitSomething = true;
            isGrounded = true;
        }
        Debug.DrawRay(transform.position + offset, -Vector3.up *rayLength, hitColor);
        return hitSomething;
    }
}

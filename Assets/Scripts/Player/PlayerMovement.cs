using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkGroundDistance;

    private float move;
    public float Move
    {
        get { return move; }
        set { move = value; }
    }

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        checkGroundDistance = transform.localScale.y/1.9f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkGroundRotation();
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }

    public void Jump()
    {
        if(!isJumping)
            rb.AddForce(new Vector2(rb.velocity.x, jump));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    private void checkGroundRotation()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkGroundDistance, groundLayer);
        // If it hits something...
        if (hit.collider != null)
        {
            //transform.rotation = Quaternion.EulerAngles(0, 0, Mathf.Atan2(hit.normal.y, hit.normal.x));
        }
    }
}

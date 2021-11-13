using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkGroundDistance, deltaX;
    private AnimationManager animationManager;
    private SpriteRenderer spriteRenderer;


    [SerializeField] private static bool canMove = true;
    public static bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    private static float move;
    public static float Move
    {
        get { return move; }
        set
        {
            if (canMove)
            { move = value; }
        }
    }

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animationManager = GetComponent<AnimationManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkGroundRotation();
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        animationManager.SetSpeed(Mathf.Abs(rb.velocity.x));
    }

    public void Jump()
    {
        if(!isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
        }
    }

    private void checkGroundRotation()
    {
        // Cast a ray straight down.
        RaycastHit2D hit1 = Physics2D.Raycast(new Vector3(transform.position.x - deltaX, transform.position.y, transform.position.z), Vector2.down, checkGroundDistance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z), Vector2.down, checkGroundDistance, groundLayer);
        // If it hits something...
        if (hit1.collider != null)
        {
            animationManager.SetJump(false);
            isJumping = false;
            //transform.rotation = Quaternion.EulerAngles(0, 0, (Mathf.Atan2(hit1.normal.y, hit1.normal.x) * Mathf.Rad2Deg));
        }
        else if (hit2.collider != null)
        {
            isJumping = false;
            animationManager.SetJump(false);
            //transform.rotation = Quaternion.EulerAngles(0, 0, (Mathf.Atan2(hit2.normal.y, hit2.normal.x) * Mathf.Rad2Deg));
        }
        else
        {
            animationManager.SetJump(true);
            isJumping = true;
        }

    }
}

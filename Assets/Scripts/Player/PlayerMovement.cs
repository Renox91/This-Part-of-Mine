using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float acceleration;
    [SerializeField] public float stopDeceleration;
    [SerializeField] public float turnDeceleration;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float climbSpeed;
    [SerializeField] private float climbDistance;

    private List<ContactPoint2D> contactList;

    private new BoxCollider2D collider;
    private Collider2D lastGroundCollider;
    private Collider2D lastWallCollider;

    private AnimationManager animationManager;
    private SpriteRenderer spriteRenderer;

    private bool isJumping = false;
    private bool inAir = false;
    private bool touchingWalls = false;
    private bool climbed = false;
    private bool fromLeft = false;

    private float previousGravityScale;
    private bool isOnIce;
    private bool isTalkingToBunny = false;
    private static bool canMove = false;
    public static bool CanMove
    {
        get { return canMove; }
        set { canMove = value; if (!canMove) move = 0f; }
    }

    private static float move;
    public static float Move
    {
        get { return canMove ? move : 0f; }
        set { move = value; }
    }

    public static bool CanClimb { get; set; } = false;

    private Rigidbody2D rb;
    // Start is called before the a first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animationManager = GetComponent<AnimationManager>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        contactList = new List<ContactPoint2D>();
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            float acceleration;
            float targetHorSpeed = move * speed;
            var vel = rb.velocity;

            if (Mathf.Abs(targetHorSpeed) < 0.0625f)
                acceleration = stopDeceleration;
            else if (targetHorSpeed * vel.x < 0f)
                acceleration = turnDeceleration;
            else acceleration = this.acceleration;

            if (vel.x < targetHorSpeed)
                vel.x = Mathf.Min(vel.x + acceleration * Time.fixedDeltaTime, targetHorSpeed);
            else if (vel.x > targetHorSpeed)
                vel.x = Mathf.Max(vel.x - acceleration * Time.fixedDeltaTime, targetHorSpeed);
            if (isOnIce)
                rb.velocity = vel;
            else
                rb.velocity = new Vector2(move * speed, rb.velocity.y);
            if (rb.velocity.x < 0)
                spriteRenderer.flipX = true;
            else if (rb.velocity.x > 0)
                spriteRenderer.flipX = false;
            animationManager.SetSpeed(Mathf.Abs(rb.velocity.x));
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (isTalkingToBunny)
        {
            if (transform.position.x > -240.72f) 
            {
                rb.velocity = new Vector2(-speed/2f,0f);
                animationManager.SetSpeed(Mathf.Abs(rb.velocity.x));
                spriteRenderer.flipX = true;
            }
            else 
            {
                rb.velocity = new Vector2(0f,0f);
                animationManager.SetSpeed(Mathf.Abs(rb.velocity.x));
            }
        }
    }

    public void Jump()
    {
        if (!inAir && !(isTalkingToBunny))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
            inAir = true;
        }
    }

    public void TryClimbing()
    {
        if (CanClimb && touchingWalls && inAir && !climbed)
        {
            climbed = true;
            previousGravityScale = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = climbSpeed * Vector2.up;
            rb.SetRotation(fromLeft ? -90f : 90f);
            Invoke(nameof(StopClimbing), climbDistance / climbSpeed);
        }
    }

    void StopClimbing()
    {
        rb.gravityScale = previousGravityScale;
        rb.SetRotation(0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var numContacts = collision.GetContacts(contactList);

        for (int i = 0; i < numContacts; i++)
        {
            if (contactList[i].normal.y == 0) // totally horizontal normal
            {
                lastWallCollider = collision.collider;
                TouchedWalls();
                fromLeft = Mathf.Sign(contactList[i].normal.x) == 1f;
            }
            else
            {
                lastGroundCollider = collision.collider;
                TouchedGround();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider == lastGroundCollider)
        {
            LeavingGround();
            lastGroundCollider = null;
        }
        else if (collision.collider == lastWallCollider)
        {
            ReleasingWalls();
            lastWallCollider = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D zone)
    {
        if (zone.tag == "bunny")
        {
            canMove = false;
            isTalkingToBunny = true;
        }
    }

    void TouchedGround()
    {
        animationManager.SetJump(false);
        inAir = false;
        isJumping = false;
        climbed = false;
    }

    void LeavingGround()
    {
        animationManager.SetJump(true);
        inAir = true;
    }

    void TouchedWalls()
    {
        touchingWalls = true;
    }

    void ReleasingWalls()
    {
        touchingWalls = false;
    }
}

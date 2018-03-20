using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 300f;
    public float maxSpeed = 5f;
    public float jumpForce = 800f;
    public Transform groundCheckLeft;
	public Transform groundCheckRight;


    private bool grounded = false;
	private bool walled = true;
    private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground"))
					|| Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed && (!walled || grounded))
            rb2d.AddForce(Vector2.right * h * moveForce);

		if (walled && !grounded && rb2d.velocity.y < -5) {
			rb2d.AddForce(new Vector2(0f, rb2d.velocity.y + 10));
		}

        if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip ();
        else if (h < 0 && facingRight)
            Flip ();

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Animator animator;
    private Rigidbody2D rb2d;

    public float horizontalMov;
    public float verticalMov;
    public float speed;
    public float jumpforce;
    public bool isJumping = false;
    bool facingRight = true;
    //private bool m_FacingRight = true;  

    bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMov = Input.GetAxisRaw("Horizontal") * speed;
        verticalMov = Input.GetAxisRaw("Vertical") * speed;

        animator.SetFloat("Speed", horizontalMov);
        animator.SetBool("Jump", false);

        if (verticalMov > 0f)
        {
            isJump = true;
            animator.SetBool("Jump", true);
        }


    }

    void FixedUpdate()
    {
        if (horizontalMov > 0 && !facingRight)
        {
            Flip();
        }
        if (horizontalMov < 0 && facingRight)
        {
            Flip();
        }

        if (horizontalMov > 0.1f || horizontalMov < -0.1f)
        {
            rb2d.AddForce(new Vector2(horizontalMov * speed, 0f), ForceMode2D.Impulse);
        }

        if (verticalMov > 0f && !isJumping)
        {
            rb2d.AddForce(new Vector2(0f, jumpforce * verticalMov), ForceMode2D.Impulse);
        }

    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
            animator.SetBool("Jump", false);
        }

        else if(collision.gameObject.tag == "Spike")
        {
            Application.LoadLevel("HardlightLevel1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = true;
            animator.SetBool("Jump", true);
        }
    }

    

}

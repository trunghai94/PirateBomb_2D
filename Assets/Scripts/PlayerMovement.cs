using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rd;
    public Animator aim;

    private float horizontal;
    private bool isFacingRight = true;
    private bool isGround = false;
    private bool isJump;

    public float speed = 5f;
    public float jump = 10f;
    public GameObject jumpParticles;
    public GameObject jumpPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        aim = GetComponent<Animator>();
    }

    // Update is called once per framese
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Flip();
    }

    private void FixedUpdate()
    {
        rd.velocity = new Vector2(horizontal * speed, rd.velocity.y);
        if (horizontal == 0) aim.SetBool("Run", false);
        else aim.SetBool("Run", true);

        if (Input.GetKey(KeyCode.Space) && isGround == true)
        {
            GameObject jumpPcl = Instantiate(jumpPrefabs, jumpParticles.transform.position, Quaternion.identity);
            Destroy(jumpPcl, 0.4f);
            rd.velocity = new Vector2(rd.velocity.x,jump);
            isGround = false;
            isJump = true;
        }
        aim.SetBool("Jump", isJump);

    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            isJump = false;
        }

        if (collision.gameObject.CompareTag("Bomb") && CharacterBomb.checkExplosion == true)
        {
            aim.SetBool("Hit", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        aim.SetBool("Hit", false);
    }

}

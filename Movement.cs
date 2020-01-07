using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public string horizontal_axis_name = "Horizontal";
    //public string vertical_axis_name = "Vertical";

    Rigidbody2D rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public int speed = 5;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay2D()
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        float displacement_x = Input.GetAxis(horizontal_axis_name) * speed * time;
        transform.position += new Vector3(displacement_x, 0, 0);

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * time;
        }
        else if(rb.velocity.y > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * time;
        }
        /*if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }*/

    }
}

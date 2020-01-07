using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour
{
    public string horizontal_axis_name = "Horizontal";
    //public string vertical_axis_name = "Vertical";

    Rigidbody2D rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public int speed = 2;
    public static float healthAmount;

    //public Vector2 jump;
    public float jumpForce = 1.0f;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 1;
        rb = GetComponent<Rigidbody2D>();
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
    }


    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0){
			Destroy (gameObject);
        }

        float time = Time.deltaTime;
        float displacement_x = Input.GetAxis(horizontal_axis_name) * speed * time;
        transform.position += new Vector3(displacement_x, 0, 0);

        if (Input.GetButton("Jump") && isGrounded)
        {
			//Debug.Log("The jump button registers");
			rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
			//rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * time;
        }
        else if(rb.velocity.y > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * time;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
	{
		
	}
    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("Spike"))
			healthAmount -= 0.1f;
	}

    void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

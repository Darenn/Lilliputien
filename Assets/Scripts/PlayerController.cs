using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public float MovingForce;
    public float MaxVelocity;
    public float JumpForce;
    public float TimeToUnreachCore;

    private Rigidbody2D rigidbody;
    private bool IsOnGround = false;
    private Percing percing;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody.AddRelativeForce(new Vector2(MovingForce * move.x, 0));

        if (Input.GetButtonDown("Jump") && IsOnGround)
        {
            rigidbody.AddRelativeForce(new Vector2(0, JumpForce));
            IsOnGround = false;
        }

        if (Mathf.Abs(rigidbody.velocity.x) > MaxVelocity)
        {
            rigidbody.velocity = new Vector2(MaxVelocity * Mathf.Sign(rigidbody.velocity.x), rigidbody.velocity.y);
        }

        if (Mathf.Abs(rigidbody.velocity.y) > MaxVelocity)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, MaxVelocity * Mathf.Sign(rigidbody.velocity.y));
        }

        if (Input.GetButton("Fire1") && percing != null)
        {
            percing.Unearth(TimeToUnreachCore);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsOnGround = true;
        if (collision.CompareTag("Percing"))
        {
            percing = collision.GetComponent<Percing>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Percing"))
        {
            percing = null;
        }
    }
}

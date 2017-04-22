using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public float MovingForce;
    public float MaxVelocity;
    public float JumpForce;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody.AddRelativeForce(new Vector2(MovingForce * move.x, 0));

        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.AddRelativeForce(new Vector2(0, JumpForce));
        }

        if (Mathf.Abs(rigidbody.velocity.x) > MaxVelocity)
        {
            rigidbody.velocity = new Vector2(MaxVelocity * Mathf.Sign(rigidbody.velocity.x), rigidbody.velocity.y);
        }

        if (Mathf.Abs(rigidbody.velocity.y) > MaxVelocity)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, MaxVelocity * Mathf.Sign(rigidbody.velocity.y));
        }
    }
}

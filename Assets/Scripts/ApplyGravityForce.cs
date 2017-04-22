using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ApplyGravityForce : MonoBehaviour {

    public float GravityForce;

    private List<Rigidbody2D> inRangeObjects;

    private void Awake()
    {
        inRangeObjects = new List<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        foreach(Rigidbody2D rb in inRangeObjects)
        {
            rb.AddForce((transform.position - rb.transform.position).normalized * GravityForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D otherRigibody = other.GetComponent<Rigidbody2D>();
        if (otherRigibody)
        {
            inRangeObjects.Add(otherRigibody);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inRangeObjects.Remove(other.GetComponent<Rigidbody2D>());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Modify the rotation
        Vector2 C = transform.position.normalized - other.transform.position;
        float Angle = Mathf.Atan2(C.y, C.x);
        float AngleInDegrees = Angle * Mathf.Rad2Deg;
        other.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 + AngleInDegrees));
    }
}

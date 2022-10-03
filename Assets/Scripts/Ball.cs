using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rigidbody;

    private float speed = 20f;
    private Vector3 velocity;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.down * speed;
    }

    void FixedUpdate()
    {
        velocity = rigidbody.velocity.normalized * speed;
        rigidbody.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var interestedContactPoint = collision.contacts[0];
        rigidbody.velocity = Vector3.Reflect(velocity, interestedContactPoint.normal);
    }
}

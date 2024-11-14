using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private string inputAxis;

    [SerializeField]
    private Rigidbody2D rb;

    private Vector2 initialPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, Input.GetAxisRaw(inputAxis) * speed);
    }

    public void Reset() {
        rb.position = initialPosition;
    }
}

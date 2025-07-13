using UnityEngine;

public class BallConstantSpeed : MonoBehaviour
{
    public float constantSpeed = 5f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
            if (rb.velocity.magnitude != constantSpeed)
            {
                rb.velocity = rb.velocity.normalized * constantSpeed;
            }
    }
}
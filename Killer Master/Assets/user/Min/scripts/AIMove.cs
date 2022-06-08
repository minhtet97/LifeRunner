using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    public float walkSpeed;
    public Rigidbody2D rb;

    public Transform gorunCheckPos;
    private bool mustTrun;
    public LayerMask groundlayer;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }
    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTrun = !Physics2D.OverlapCircle(gorunCheckPos.position, 0.1f, groundlayer);
        }
    }

    void Patrol()
    {
        if(mustTrun)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}

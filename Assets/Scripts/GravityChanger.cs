using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour {

    public SpriteRenderer SpriteRednerer;
    public LayerMask GroundMask;
    public Transform[] GroundCheck;

    private Rigidbody2D rb;
    private bool grounded = false;
    private float groundRadius = 0.2f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(GroundCheck[SpriteRednerer.flipY ? 1 : 0].position, groundRadius, GroundMask);
    }

	// Update is called once per frame
	void Update ()
    {
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            RevertGravity();
        }
	}

    public void RevertGravity()
    {
        if(grounded)
        {
            rb.velocity = Vector2.zero;
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, Physics2D.gravity.y * -1);
            SpriteRednerer.flipY = !SpriteRednerer.flipY;
        }
    }
}

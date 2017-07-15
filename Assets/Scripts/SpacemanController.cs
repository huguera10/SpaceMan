using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacemanController : MonoBehaviour
{
    public float floatForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;

    public Transform groundCheckTransform;
    public LayerMask groundCheckLayerMask;
    public ParticleSystem jetpack;

    private bool grounded;
    private float previousAltitude;

    Animator animator;

    void Start()
    {
        previousAltitude = transform.position.y;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        bool floatActive = Input.GetButton("Fire1");

        if (floatActive)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, floatForce));
        }

        Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
        newVelocity.x = forwardMovementSpeed;
        GetComponent<Rigidbody2D>().velocity = newVelocity;

        UpdateGroundedStatus();
        UpdateEngineStatus(transform.position.y > previousAltitude);
        AdjustJetpack(floatActive);
    }

    void UpdateGroundedStatus()
    {
        grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);

        animator.SetBool("grounded", grounded);
    }

    void UpdateEngineStatus(bool falling)
    {
        animator.SetBool("engine", falling);
        previousAltitude = transform.position.y;
    }

    void AdjustJetpack(bool jetpackActive)
    {
        var emission = jetpack.emission;
        emission.enabled = !grounded;

        var rate = emission.rateOverTime;
        if (jetpackActive) rate.constantMax = 300.0f;
        else rate.constantMax = 75.0f;

        emission.rateOverTime = rate;
    }
}

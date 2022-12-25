using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        float angle = -90 * Mathf.Deg2Rad;
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        _rb.AddForce(moveDirection * ConfigurationUtils.BallImpulseForce);
        //_rb.velocity = moveDirection * ConfigurationUtils.BallImpulseForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        _rb.AddForce(direction * ConfigurationUtils.BallImpulseForce);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        this._rb.MovePosition(this.transform.position + new Vector3(horizontal * Time.deltaTime * ConfigurationUtils.PaddleMoveUnitsPerSecond, 0));
    }
}

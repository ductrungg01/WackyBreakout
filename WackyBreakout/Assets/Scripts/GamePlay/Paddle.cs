using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D _rb;
    float _halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _halfWidth = this.GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        if (horizontal != 0)
        {
            float newPosX = this.transform.position.x + horizontal * Time.deltaTime * ConfigurationUtils.PaddleMoveUnitsPerSecond;
            newPosX = CalculateClampedX(newPosX);
            this._rb.MovePosition(new Vector3(newPosX, this.transform.position.y, 0));
        }
    }

    float CalculateClampedX(float possibleNewX)
    {
        float boundLeft = ScreenUtils.ScreenLeft + _halfWidth;
        float boundRight = ScreenUtils.ScreenRight - _halfWidth;

        if (possibleNewX < boundLeft)
        {
            return boundLeft;
        }

        if (possibleNewX > boundRight)
        {
            return boundRight;
        }

        return possibleNewX;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D _rb;
    float halfColliderWidth;
    float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        halfColliderWidth = this.GetComponent<BoxCollider2D>().size.x / 2;
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
        float boundLeft = ScreenUtils.ScreenLeft + halfColliderWidth;
        float boundRight = ScreenUtils.ScreenRight - halfColliderWidth;

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

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth; 
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }
}

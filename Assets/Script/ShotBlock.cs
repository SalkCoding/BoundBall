using UnityEngine;
using System.Collections;

public class ShotBlock : MonoBehaviour
{
    public string Direction = "left";
    public float ShotSpeed = 10f;
    private Rigidbody2D ballrb = new Rigidbody2D();
    private bool shooting;
    private float gravity;

    void Update()
    {
        if (ballrb != null)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                shooting = false;
                ballrb.gravityScale = gravity;
            }
            if (shooting)
            {
                if (Direction.Equals("left"))
                    ballrb.transform.Translate(new Vector2(-ShotSpeed * Time.deltaTime, 0));
                else if (Direction.Equals("right"))
                    ballrb.transform.Translate(new Vector2(ShotSpeed * Time.deltaTime, 0));
                else if (Direction.Equals("up"))
                    ballrb.transform.Translate(new Vector2(0, ShotSpeed * Time.deltaTime));
                else if (Direction.Equals("down"))
                    ballrb.transform.Translate(new Vector2(0, -ShotSpeed * Time.deltaTime));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            shooting = true;
            ballrb = other.GetComponent<Rigidbody2D>();
            gravity = ballrb.gravityScale;
            ballrb.gravityScale = 0;
            ballrb.velocity = Vector2.zero;
            //ballrb.simulated = false;
            other.transform.position = transform.position;
        }
    }

}

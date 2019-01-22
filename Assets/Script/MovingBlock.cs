using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{

    public string direction = "LR";
    public float MovingSpeed = 3f;
    public float Distance = 10f;

    private Vector2 fix;
    private GameObject block;
    private int moveSide = 1;

    void Start()
    {
        fix = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 block = transform.position;
        if (direction.Equals("LR"))
        {
            float d = Vector2.Distance(block, new Vector2(fix.x + (Distance * moveSide), fix.y));
            if (d <= 0.5f)
                moveSide *= -1;
            transform.Translate(new Vector2(moveSide * MovingSpeed * Time.deltaTime, 0));
        }
        else if (direction.Equals("UD"))
        {
            float d = Vector2.Distance(block, new Vector2(fix.x, fix.y + (Distance * moveSide)));
            if (d <= 0.5f)
                moveSide *= -1;
            transform.Translate(new Vector2(0, moveSide * MovingSpeed * Time.deltaTime));
        }

    }
}

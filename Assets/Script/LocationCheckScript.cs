using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationCheckScript : MonoBehaviour
{
    public Vector3 RespawnLocation = new Vector3(-2.7f, 4f);//떨어졌을때 리스폰 좌표(X,Y)
    public float MIN_Y = 0;
    public float JUMP_SCALE = 7f;//점프 높이 값
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 location = transform.position;
        if (location.y < MIN_Y)
        {
            transform.position = RespawnLocation;
            GetComponent<Objective>().ResetObjective();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Brick"))
            rb.velocity = (new Vector2(0, JUMP_SCALE));
    }

}

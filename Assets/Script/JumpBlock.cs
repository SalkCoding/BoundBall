using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : MonoBehaviour {

    public float AddForce = 30f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            var rb = other.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, AddForce));
        }
    }

}

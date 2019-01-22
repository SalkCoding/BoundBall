using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTouch : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
            other.transform.Translate(new Vector2(0, -100));
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BreakingBlock : MonoBehaviour
{

    public int count = 1;
    private int check;
    public int resetTime = 3;
    private BoxCollider2D box;
    private new SpriteRenderer renderer;
    private Stopwatch stopwatch = new Stopwatch();

    void Start()
    {
        check = count;
        box = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (stopwatch.IsRunning)
        {
            if (stopwatch.ElapsedMilliseconds > resetTime * 1000)
            {
                check = count; 
                box.enabled = true;
                renderer.enabled = true;
                stopwatch.Stop();
                stopwatch.Reset();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (check - 1 == 0)
            {
                box.enabled = false;
                renderer.enabled = false;
                stopwatch.Start();
            }
            else
                check--;
        }

    }
}

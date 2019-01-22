using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour {

    public int NeedObjective = 1;
    public string NextScene = "sence";
    private int count = 0;
    private List<Collider2D> gems = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Gem")){
            GemDestory(other);
            count++;
            if(count >= NeedObjective)
                SceneManager.LoadScene(NextScene);
        }
    }

    void GemDestory(Collider2D gem)
    {
        var render = gem.GetComponent<SpriteRenderer>();
        var rb = gem.GetComponent<BoxCollider2D>();
        rb.enabled = false;
        render.enabled = false;
        gems.Add(gem);
    }

    public void ResetObjective()
    {
        foreach(Collider2D gem in gems)
        {
            var render = gem.GetComponent<SpriteRenderer>();
            var rb = gem.GetComponent<BoxCollider2D>();
            rb.enabled = true;
            render.enabled = true;
        }
        gems.Clear();
        count = 0;
    }

}

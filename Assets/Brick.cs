using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject BrickSpawner;
    public int Health = 1;
    // Start is called before the first frame update
    void Start()
    {
        BrickSpawner = GameObject.Find("BrickSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Ball")
        {
            Health--;
            if (Health <= 0)
            {
                int thisIndex = BrickSpawner.GetComponent<BrickSpawner>().BrickList.IndexOf(gameObject);
                BrickSpawner.GetComponent<BrickSpawner>().BrickList.RemoveAt(thisIndex);
                Destroy(this.gameObject);
            }
        }
    }
}

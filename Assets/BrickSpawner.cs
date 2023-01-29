using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject RedBrickPrefab;
    public GameObject OrangeBrickPrefab;
    public int Height;
    public int Wide;

    void Start()
    {
        for (int i = 0 ; i < Height; i++)
            for (int j =0; j< Wide; j++)
            {
                var newBrick = Instantiate(RedBrickPrefab, transform);
                newBrick.transform.position = new Vector3(-2.5f+j,-1+i*0.5f,0);
            }

        for (int i = 0 ; i < Height; i++)
            for (int j =0; j< Wide; j++)
            {
                var newBrick = Instantiate(OrangeBrickPrefab, transform);
                newBrick.transform.position = new Vector3(-2.5f+j,-1+0.5f+Height*0.5f+i*0.5f,0);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

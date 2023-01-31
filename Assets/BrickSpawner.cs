using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject RedBrickPrefab;
    public GameObject OrangeBrickPrefab;

    public static List<GameObject> BrickList;
    public int Height;
    public int Wide;

    void Start()
    {
        if (BrickList==null)
            BrickList = new List<GameObject>();

        for (int i = 0 ; i < Height; i++)
            for (int j =0; j< Wide; j++)
            {
                var newBrick = Instantiate(RedBrickPrefab, transform);
                newBrick.transform.position = new Vector3(-2.5f+j,-1+i*0.5f,0);
                BrickList.Add(newBrick);
            }

        for (int i = 0 ; i < Height; i++)
            for (int j =0; j< Wide; j++)
            {
                var newBrick = Instantiate(OrangeBrickPrefab, transform);
                newBrick.transform.position = new Vector3(-2.5f+j,-1+0.5f+Height*0.5f+i*0.5f,0);
                BrickList.Add(newBrick);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAllBrick()
    {
        BrickList.Clear();
        Debug.Log(BrickList);
    }

    public void Restart()
    {
        DestroyAllBrick();
        Start();
    }
}

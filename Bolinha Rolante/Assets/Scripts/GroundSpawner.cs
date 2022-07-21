using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawmPoint;

    public void SpawmTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawmPoint, Quaternion.identity);
        nextSpawmPoint = temp.transform.GetChild(1).transform.position;
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawmTile();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameObject BombPtrefab;

    public void CreateBomb(Transform player)
    {
        Vector3 newPosition = player.position + new Vector3(0.0f, 1.0f, 0.0f);
        Instantiate(BombPtrefab, newPosition, Quaternion.identity);
    }
}

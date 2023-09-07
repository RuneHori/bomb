using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameObject BombPrefab;

    public void CreateBomb(Transform player)
    {
        Vector3 newPosition = player.position + new Vector3(0.0f, 1.0f, 0.0f);
        GameObject bomb= Instantiate(BombPrefab, newPosition, Quaternion.identity);
        bomb.GetComponent<BombEffectScript>().Effect();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneScript : MonoBehaviour
{
    GameManager gameManager = GameManager.instance;
   
    public Transform parent; //¶¬êŠw’è
    public GameObject wall;//áŠQ•Çƒ‰ƒ“ƒ_ƒ€Ši”[•Ï”

    private void Start()
    {
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);
    }
}

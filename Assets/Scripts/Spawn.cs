using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDroppedItem()
    {
        Vector3 playerPos = new Vector3(player.position.x-2, player.position.y, player.position.z);
        Instantiate(item, playerPos, Quaternion.identity);
        item.transform.localScale = new Vector3(10, 10, 10);
    }
}

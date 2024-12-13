using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject cube;
    public GameObject monsterPrefab;
    public int monsterCount;
    void Start()
    {
        SpawnMonster(monsterCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnMonster(int monsterCount)
    {
        BoxCollider boxCollider = cube.GetComponent<BoxCollider>();
        for (int i = 0; i < monsterCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(boxCollider.bounds.min.x,
                boxCollider.bounds.max.x), 5, Random.Range(boxCollider.bounds.min.z,
                boxCollider.bounds.max.z));
            GameObject monster = (GameObject)Instantiate(monsterPrefab, spawnPos, Quaternion.identity);   
        }
    }
}

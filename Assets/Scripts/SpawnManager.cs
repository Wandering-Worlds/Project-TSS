using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] protected GameObject[] spawnerList;
    [SerializeField] protected GameObject[] enemyType;
    [SerializeField] private float spawnInterval = 3f;

    private int randomSpawnIndex;
    private GameObject refToPlayer;
    

    // Start is called before the first frame update
    private void Start()
    {
        refToPlayer = GameObject.FindWithTag("Player");
        if (refToPlayer != null)
        {
            InvokeRepeating(nameof(SpawnEnemy1), 0, spawnInterval);
            InvokeRepeating(nameof(SpawnEnemy2), 0, spawnInterval * 2);
        }
    }

    // Update is called once per frame
    private void SpawnEnemy1()
    {
        if (refToPlayer.activeInHierarchy)
        {
            randomSpawnIndex = Random.Range(0, spawnerList.Length);
            Instantiate(enemyType[0], spawnerList[randomSpawnIndex].transform.position, Quaternion.identity);
        }
    }

    private void SpawnEnemy2()
    {
        if (refToPlayer.activeInHierarchy)
        {
            randomSpawnIndex = Random.Range(0, spawnerList.Length);
            Instantiate(enemyType[1], spawnerList[randomSpawnIndex].transform.position, Quaternion.identity);
        }
    }
}

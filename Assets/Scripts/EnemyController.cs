using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefabs;
    [SerializeField] EnemyScriptable[] enemyScriptable;
    [SerializeField] int NumberOfCreations;
    [SerializeField] Transform[] CreationLocation;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumberOfCreations; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefabs, CreationLocation[i].position, Quaternion.identity);
            var Enemy = enemy.GetComponent<EnemySkin>();
            Enemy.SetUpEnemy(enemyScriptable[i%enemyScriptable.Length]);
        }
    }

}

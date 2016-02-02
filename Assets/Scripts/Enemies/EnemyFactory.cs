using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private float maxSpawnHeight;
    [SerializeField]
    private float minSpawnHeight;
    private GameObject selectedEnemy;
    private Vector3 spawnLoc;

    // Timer variables
    private float spawnTime = 1;
    private float timer;


    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > spawnTime)
        {
            spawnEnemy(Random.Range(1, 3), Random.Range(1, 2));
            timer = 0;
        }
    }

    private void spawnEnemy(int type, int amt)
    {
        for (int i = 0; i < amt; i++)
        {
            switch (type)
            {
                case 1: // Air
                    selectedEnemy = enemies[0];
                    spawnLoc = new Vector3(this.transform.position.x, Random.Range(minSpawnHeight, maxSpawnHeight), 0);
                    break;
                case 2: // Ground
                    selectedEnemy = enemies[1];
					spawnLoc = new Vector3(this.transform.position.x, this.transform.position.y, 0);
                    break;
            }
            Instantiate(selectedEnemy, spawnLoc, Quaternion.identity);
        }
    }
}

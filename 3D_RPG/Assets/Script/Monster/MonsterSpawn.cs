using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public Transform[] points;
    public GameObject monsterPrefab;

    public int monsterCount = 0;
    public int monsterMaxCount = 7;
    float spawnTime = 0.1f;

    void Awake()
    {
        points = GameObject.Find("MushSpawn").GetComponentsInChildren<Transform>();

        StartCoroutine(this.MakeMonster(spawnTime));
    }

    IEnumerator MakeMonster(float waitTime)
    {
        Instantiate(monsterPrefab, points[1].position, Quaternion.identity);
        monsterCount++;
        yield return new WaitForSeconds(waitTime);
        Instantiate(monsterPrefab, points[2].position, Quaternion.identity);
        monsterCount++;
        yield return new WaitForSeconds(waitTime);
        Instantiate(monsterPrefab, points[3].position, Quaternion.identity);
        monsterCount++;
        yield return new WaitForSeconds(waitTime);
        Instantiate(monsterPrefab, points[4].position, Quaternion.identity);
        monsterCount++;
        yield return new WaitForSeconds(waitTime);
        Instantiate(monsterPrefab, points[5].position, Quaternion.identity);
        monsterCount++;
        yield return new WaitForSeconds(waitTime);
        Instantiate(monsterPrefab, points[6].position, Quaternion.identity);
        monsterCount++;
        yield return new WaitForSeconds(waitTime);
        Instantiate(monsterPrefab, points[7].position, Quaternion.identity);
        monsterCount++;
        yield return new WaitForSeconds(waitTime);
    }

    public void ReSpawn()
    {
        for(int i = 1; i <= monsterMaxCount; i++)
        {
            Instantiate(monsterPrefab, points[i].position, Quaternion.identity);
            monsterCount++;
        }
    }

    void Update()
    {
        if (monsterCount == 0)
        {
            ReSpawn();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public Transform[] points;
    public GameObject monsterPrefab;

    public int monsterCount = 0;
    public int monsterMaxCount = 7;
    float spawnTime = 1;

    void Awake()
    {
        points = GameObject.Find("MushSpawn").GetComponentsInChildren<Transform>();
        StartCoroutine(this.MakeMonster(spawnTime));
    }

    IEnumerator MakeMonster(float waitTime)
    {
        for (int i = monsterCount; monsterCount <= monsterMaxCount; monsterCount++)
        {
            int idx = Random.Range(1, points.Length);
            Instantiate(monsterPrefab, points[idx].position, Quaternion.identity);
            monsterCount++;
            yield return new WaitForSeconds(waitTime);
        }
    }
}

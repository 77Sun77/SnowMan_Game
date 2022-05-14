using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject monster;
    public List<Transform> spawnPoint = new List<Transform>();

    float time; 

    void Awake()
    {
        instance = this;
        time = 3f;
    }

    void Update()
    {
        if(time < 0) MonsterSpawn();
        else time -= Time.deltaTime;
    }

    void MonsterSpawn()
    {
        GameObject monsterGO = Instantiate(monster);
        monsterGO.transform.position = spawnPoint[Random.Range(0,2)].position;
        time = Random.Range(1f, 3f);
    }
}

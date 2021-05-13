using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour {
    public Path[] listpath;
    public GameObject Enemy;
    public float SpawnRate = 1.0f; // số enemy trong 1 giây
    float Duration = 0.0f;

     
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Duration > 2.0f / SpawnRate)
        {
            createEnemy();
            Duration = 0.0f;
        }
        Duration = Duration + Time.deltaTime;
	}
    void createEnemy()
    {
        int indexpath = Random.Range(0, listpath.Length);
        GameObject enemyClone = (GameObject)GameObject.Instantiate(Enemy, listpath[indexpath].ListPoints[0].position, Quaternion.identity);
        enemyClone.GetComponent<EnemyBehavior>().MovingPath = listpath[indexpath]; 
    }
}

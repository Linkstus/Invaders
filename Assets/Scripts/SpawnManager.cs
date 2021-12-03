using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] prefab;
    public int enemiesDefeated = 0;
    public int level = 1;

    private int waitForSpawn = 200;
    private int currentSpawnTime = 0;
    private int numEnemies = 3;
    private int enemyCount = 0;
    private PlayerController playerScript;

    // private Vector2 directionDown = new Vector2(0, 0);
    // private int numEnemies = 5;
    // Start is called before the first frame update
    void Start()
    {
      playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }



    // Update is called once per frame
    void Update()
    {
      if(playerScript.gameOver == false){
        if(enemyCount < numEnemies){

          if(currentSpawnTime == waitForSpawn){
            if(level >= 3){
              int enemyIndex = Random.Range(0, prefab.Length);
              if(enemyIndex == 0){
                Instantiate(prefab[enemyIndex], transform.position, prefab[enemyIndex].transform.rotation);
              }else{
                Instantiate(prefab[enemyIndex], new Vector2(11.5f, transform.position.y), prefab[enemyIndex].transform.rotation);
              }
            }else{
              Instantiate(prefab[0], transform.position, prefab[0].transform.rotation);
            }
            currentSpawnTime = 0;
            enemyCount++;
          }
          currentSpawnTime++;
        }


        if(enemiesDefeated == numEnemies){
          Debug.Log($"Level {level} complete!");
          enemiesDefeated = 0;
          numEnemies *= level;
          enemyCount = 0;
          level++;
        }
      }
    }
}

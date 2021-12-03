using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    private GameObject spawnManager;
    private SpawnManager sp;
    private ScoreScript score;
    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
      spawnManager = GameObject.Find("SpawnManager");
      sp = spawnManager.GetComponent<SpawnManager>();
      score = GameObject.Find("Score").GetComponent<ScoreScript>();
      playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //things to Destroy
    //enemy collide player
    //projectile collide with enemy
    //enemeyprojectile collide with player

    void playerCollision(){
      Debug.Log("You lost a life");
      playerScript.lives--;
      Debug.Log(playerScript.lives);
    }

    void OnTriggerEnter2D(Collider2D other){
      if(gameObject.tag == "Projectile"){
        //collides with enemy
        if(other.tag == "Enemy"){
          Destroy(gameObject);
          Destroy(other.gameObject);
          sp.enemiesDefeated++;
          score.score += 10;
        }
      }else if(gameObject.tag == "Enemy"){
        //collides with player
        if(other.tag == "Player"){
          Destroy(gameObject);
          playerCollision();
          sp.enemiesDefeated++;
        }
      }
      else if(gameObject.tag == "Player"){
        //collides with enemyProjectile
        if(other.tag == "EnemyProjectile"){
          playerCollision();
          Destroy(other.gameObject);
        }
      }


      if(playerScript.lives == 0){
        Debug.Log("Game Over!");
        Destroy(GameObject.Find("Player"));
        playerScript.gameOver = true;
      }


      // if(gameObject.tag == "Enemy"){
      //   if(gameObject.tag != "enemyProjectile"){
      //     Destroy(gameObject);
      //   }
      //   Destroy(other.gameObject);
      //   sp.enemiesDefeated++;
      //   score.score += 10;
      // }
      // if(other.tag == "Player"){
      //   Destroy(gameObject);
      //   Debug.Log("You lost a life!");
      //   playerScript.lives--;
      //   Debug.Log(playerScript.lives);
      // }
      //
    }
}

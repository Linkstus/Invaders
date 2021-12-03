using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemies2 : MonoBehaviour
{
    public  GameObject projectilePrefab;

    private int speed;
    private float limit = 11.5f;

    private Vector3 direction = Vector3.left;
    private PlayerController playerScript;
    private int fireTimer = 0;
    private int fire;
    // Start is called before the first frame update
    void Start()
    {
      speed = Random.Range(1, 10);
      playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
      fire = Random.Range(100, 700);
    }

    // Update is called once per frame
    void Update()
    {
      if(playerScript.gameOver == false){
        if(transform.position.x >= limit){
          transform.position = new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.z);
          direction = Vector3.left;
        }else if(transform.position.x <= -limit){
          transform.position = new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z);
          direction = Vector3.right;
        }
        transform.Translate(direction * Time.deltaTime * speed);

        if(fireTimer == fire){
          Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
          fireTimer = 0;
          fire = Random.Range(100, 700);
        }
        fireTimer++;
      }
    }
}

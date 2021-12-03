using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int speed = 10;
    private float limit = 11.5f;
    private SpawnManager spawner1;
    private int shootTimer = 100;

    public GameObject projectilePrefab;
    public GameObject laserPrefab;
    public bool gameOver = false;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
      spawner1 = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.X)){
          spawner1.level++;
        }

        if(lives == 0){
          gameOver = true;
        }

        if(!gameOver){
          if(transform.position.x > limit){
            transform.position = new Vector3(limit, transform.position.y, transform.position.z);
          }else if(transform.position.x < -limit){
            transform.position = new Vector3(-limit, transform.position.y, transform.position.z);
          }

          transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

          if(Input.GetKeyDown(KeyCode.Space) && shootTimer == 0){
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            shootTimer = 100;
          }
          if(shootTimer > 0){
            shootTimer--;
          }
        }
    }
}

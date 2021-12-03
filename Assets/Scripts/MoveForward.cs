using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    private int speed = 10;
    private float upperlimit = 7;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(transform.position.y > upperlimit){
        Destroy(gameObject);
      }

      transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}

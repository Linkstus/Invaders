using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{

    public int level;
    Text textLevel;
    // Start is called before the first frame update
    void Start()
    {
        textLevel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        level = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().level;
        textLevel.text = $"Wave: {level}";
    }
}

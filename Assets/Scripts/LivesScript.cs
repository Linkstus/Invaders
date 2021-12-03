using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour
{
    private PlayerController playerScript;
    Text liveText;

    // Start is called before the first frame update
    void Start()
    {
        liveText = GetComponent<Text>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

      liveText.text = $"Lives: {playerScript.lives}";
    }
}

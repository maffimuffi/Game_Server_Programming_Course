using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    

    Text Treasure;

    // Start is called before the first frame update
    void Start()
    {
        Treasure = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Treasure.text = "Score: " + Movement.score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hud : MonoBehaviour
{
    public static float amount = 0;
    

    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        amount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        amount = Movement.score;
        score.text = "Score: " + amount;
    }
}

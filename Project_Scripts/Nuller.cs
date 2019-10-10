using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score1", 0);
        PlayerPrefs.SetInt("score2", 0);
        PlayerPrefs.SetInt("score3", 0);
        PlayerPrefs.SetInt("score4", 0);
        PlayerPrefs.SetInt("score5", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

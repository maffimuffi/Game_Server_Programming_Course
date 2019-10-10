using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class characterCreator : MonoBehaviour
{
    public InputField playerName;

    public static string charName;

    public static Guid id;

    public void OnSubmit()
    {
        charName = playerName.text;


        Debug.Log("Name: " + charName);

        id = Guid.NewGuid();

        SceneManager.LoadScene("SampleScene");
    }


}

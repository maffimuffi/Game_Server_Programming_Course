using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{

    public string userName;
    public int userScore;
    public Guid id;

    public User()
    {
        id = characterCreator.id;
        userName = characterCreator.charName;
        userScore = Movement.score;
        Debug.Log(Movement.score);
        Debug.Log(characterCreator.charName);
    }


}

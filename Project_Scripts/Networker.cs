using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;


public class Networker : MonoBehaviour
{
    private string apiKey = "8c15e650-896d-4f4d-bede-3f4966ab6381";
    private string mlabUrl = "mongodb+srv://Game:<Mongooli>@highscore-wwc9v.azure.mongodb.net/test?retryWrites=true&w=majority";
    









    [System.Serializable]
        public class Score
    {
        public int score = Movement.score;
        public string name, date, deviceID;
    }

    public IEnumerator UpdateHighScore(int newHighScore)
    {
        string request = mlabUrl
              + "?&q={\"deviceID\":\"" + SystemInfo.deviceUniqueIdentifier + "\"}"
              + "&m=true&u=true&apiKey=" + apiKey;

        Score scoreData = new Score();
        scoreData.score = newHighScore;
        scoreData.name = characterCreator.charName;
        scoreData.date = System.DateTime.Now.ToString();
        scoreData.deviceID = SystemInfo.deviceUniqueIdentifier;

        string json = JsonUtility.ToJson(scoreData);
        json = "{ \"$set\" : " + json + "}";
        var scoreBytes = System.Text.Encoding.UTF8.GetBytes(json);

        UnityWebRequest www = UnityWebRequest.Put(request, scoreBytes);
        www.SetRequestHeader("content-type", "application/json");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("New high score set to " + newHighScore.ToString());
        }
    }

    public static Networker instance;

    

    void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public Score[] scores;
    

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }

    public IEnumerator GetScores()
    {
        UnityWebRequest www = UnityWebRequest.Get(mlabUrl + "?&apiKey=" + apiKey);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string json = "{ \"array\": " + www.downloadHandler.text + "}";
            Wrapper<Score> wrapper = JsonUtility.FromJson<Wrapper<Score>>(json);
            scores = wrapper.array.OrderByDescending(go => go.score).ToArray();
        }
    }

}

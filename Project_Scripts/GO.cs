using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GO : MonoBehaviour
{
    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;

    public Text nameText1;
    public Text nameText2;
    public Text nameText3;
    public Text nameText4;
    public Text nameText5;

    public static int first;
    public static int second;
    public static int third;
    public static int fourth;
    public static int fifth;

    bool went;


    public static User user1 = new User();
    public static User user2 = new User();
    public static User user3 = new User();
    public static User user4 = new User();
    public static User user5 = new User();


    // Start is called before the first frame update
    void Start()
    {
        went = false;
        first = PlayerPrefs.GetInt("score1", first);
        second = PlayerPrefs.GetInt("score2", second);
        third = PlayerPrefs.GetInt("score3", third);
        fourth = PlayerPrefs.GetInt("score4", fourth);
        fifth = PlayerPrefs.GetInt("score5", fifth);




    }

    // Update is called once per frame
    void Update()
    {

        //GetScores();
        

        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }


        if(first < Movement.score && went == false)
        {

            went = true;

            fifth = PlayerPrefs.GetInt("score4", fourth);
            fourth = PlayerPrefs.GetInt("score3", third);
            third = PlayerPrefs.GetInt("score2", second);
            second = PlayerPrefs.GetInt("score2", first);
            first = Movement.score;

            PlayerPrefs.SetInt("score1", first);
            PlayerPrefs.SetInt("score2", second);
            PlayerPrefs.SetInt("score3", third);
            PlayerPrefs.SetInt("score4", fourth);
            PlayerPrefs.SetInt("score5", fifth);

            //name1 = characterCreator.charName;

            

            GetScores(PlayerPrefs.GetInt("score1", first), PlayerPrefs.GetInt("score2", second), PlayerPrefs.GetInt("score3", third), PlayerPrefs.GetInt("score4", fourth), PlayerPrefs.GetInt("score5", fifth));
        }

        else if (second < Movement.score && second < first && went == false)
        {
            went = true;

            fifth = PlayerPrefs.GetInt("score4", fourth);
            fourth = PlayerPrefs.GetInt("score3", third);
            third = PlayerPrefs.GetInt("score2", second);
            second = Movement.score;

            
            PlayerPrefs.SetInt("score2", second);
            PlayerPrefs.SetInt("score3", third);
            PlayerPrefs.SetInt("score4", fourth);
            PlayerPrefs.SetInt("score5", fifth);



            GetScores(PlayerPrefs.GetInt("score1", first), PlayerPrefs.GetInt("score2", second), PlayerPrefs.GetInt("score3", third), PlayerPrefs.GetInt("score4", fourth), PlayerPrefs.GetInt("score5", fifth));
        }

        else if (third < Movement.score && third < first && third < second && went == false)
        {

            went = true;

            fifth = PlayerPrefs.GetInt("score4", fourth);
            fourth = PlayerPrefs.GetInt("score3", third);
            third = Movement.score;


            
            PlayerPrefs.SetInt("score3", third);
            PlayerPrefs.SetInt("score4", fourth);
            PlayerPrefs.SetInt("score5", fifth);



            GetScores(PlayerPrefs.GetInt("score1", first), PlayerPrefs.GetInt("score2", second), PlayerPrefs.GetInt("score3", third), PlayerPrefs.GetInt("score4", fourth), PlayerPrefs.GetInt("score5", fifth));
        }

        else if (fourth < Movement.score && fourth < first && fourth < second && fourth < third && went == false)
        {
            went = true;

            fifth = PlayerPrefs.GetInt("score4", fourth);
            fourth = Movement.score;



            
            PlayerPrefs.SetInt("score4", fourth);
            PlayerPrefs.SetInt("score5", fifth);



            GetScores(PlayerPrefs.GetInt("score1", first), PlayerPrefs.GetInt("score2", second), PlayerPrefs.GetInt("score3", third), PlayerPrefs.GetInt("score4", fourth), PlayerPrefs.GetInt("score5", fifth));
        }


        else if (fifth < Movement.score && fifth < first && fifth < second && fifth < third && fifth < fourth && went == false)
        {

            went = true;

            fifth = Movement.score;



            
            PlayerPrefs.SetInt("score5", fifth);



            GetScores(PlayerPrefs.GetInt("score1", first), PlayerPrefs.GetInt("score2", second), PlayerPrefs.GetInt("score3", third), PlayerPrefs.GetInt("score4", fourth), PlayerPrefs.GetInt("score5", fifth));
        }

        else if(first == Movement.score && went == false)
        {

            went = true;

            fifth = PlayerPrefs.GetInt("score4", fourth);
            fourth = PlayerPrefs.GetInt("score3", third);
            third = PlayerPrefs.GetInt("score2", second);
            second = Movement.score;



           
            PlayerPrefs.SetInt("score2", second);
            PlayerPrefs.SetInt("score3", third);
            PlayerPrefs.SetInt("score4", fourth);
            PlayerPrefs.SetInt("score5", fifth);



            GetScores(PlayerPrefs.GetInt("score1", first), PlayerPrefs.GetInt("score2", second), PlayerPrefs.GetInt("score3", third), PlayerPrefs.GetInt("score4", fourth), PlayerPrefs.GetInt("score5", fifth));
        }

        else if (second == Movement.score && went == false)
        {

            went = true;

            fifth = PlayerPrefs.GetInt("score4", fourth);
            fourth = PlayerPrefs.GetInt("score3", third);
            third = Movement.score;



            
            PlayerPrefs.SetInt("score3", third);
            PlayerPrefs.SetInt("score4", fourth);
            PlayerPrefs.SetInt("score5", fifth);



            GetScores(PlayerPrefs.GetInt("score1", first), PlayerPrefs.GetInt("score2", second), PlayerPrefs.GetInt("score3", third), PlayerPrefs.GetInt("score4", fourth), PlayerPrefs.GetInt("score5", fifth));
        }

        else if (third == Movement.score && went == false)
        {

            went = true;

            fifth = PlayerPrefs.GetInt("score4", fourth);
            fourth = Movement.score;



            
            PlayerPrefs.SetInt("score4", fourth);
            PlayerPrefs.SetInt("score5", fifth);



            GetScores(PlayerPrefs.GetInt("score1", first), PlayerPrefs.GetInt("score2", second), PlayerPrefs.GetInt("score3", third), PlayerPrefs.GetInt("score4", fourth), PlayerPrefs.GetInt("score5", fifth));

        }

        else if (fourth == Movement.score && went == false)
        {

            went = true;

            fifth = Movement.score;


            
            PlayerPrefs.SetInt("score5", fifth);



            GetScores(PlayerPrefs.GetInt("score1", first), PlayerPrefs.GetInt("score2", second), PlayerPrefs.GetInt("score3", third), PlayerPrefs.GetInt("score4", fourth), PlayerPrefs.GetInt("score5", fifth));
        }

        else
        {
            went = true;
            /*PlayerPrefs.SetInt("score1", first);
            PlayerPrefs.SetInt("score2", second);
            PlayerPrefs.SetInt("score3", third);
            PlayerPrefs.SetInt("score4", fourth);
            PlayerPrefs.SetInt("score5", fifth);
            */



            GetScores(PlayerPrefs.GetInt("score1", first), PlayerPrefs.GetInt("score2", second), PlayerPrefs.GetInt("score3", third), PlayerPrefs.GetInt("score4", fourth), PlayerPrefs.GetInt("score5", fifth));
        }



    }

    public void GetScores(int score1, int score2, int score3, int score4, int score5)
    {
        RetrieveFromDatabase(score1, score2, score3, score4, score5);
    }

    

    private void UpdateScore()
    {
        score1.text = user1.userScore.ToString();
        //score1.text = PlayerPrefs.GetInt("score1", first).ToString();
        //score2.text = PlayerPrefs.GetInt("score2", second).ToString(); ;
        score2.text = user2.userScore.ToString();
        score3.text = user3.userScore.ToString();
        score4.text = user4.userScore.ToString();
        score5.text = user5.userScore.ToString();
    }

    private void UpdateName()
    {
        nameText1.text = user1.userName;
        nameText2.text = user2.userName;
        nameText3.text = user3.userName;
        nameText4.text = user4.userName;
        nameText5.text = user5.userName;
    }


    public void RetrieveFromDatabase(int score1, int score2, int score3, int score4, int score5)
    {
        try
        {
            RestClient.Get<User>("https://highscore-db5cc.firebaseio.com/" + score1 + ".json").Then(response => {
                user1 = response;
                UpdateScore();
                UpdateName();
                Debug.Log("test " + user1.userName);
            });


            RestClient.Get<User>("https://highscore-db5cc.firebaseio.com/" + score2 + ".json").Then(response => {
                user2 = response;
                UpdateScore();
                UpdateName();
                Debug.Log(user2.userName);
            });

            RestClient.Get<User>("https://highscore-db5cc.firebaseio.com/" + score3 + ".json").Then(response => {
                user3 = response;
                UpdateScore();
                UpdateName();
                Debug.Log(user3.userName);
            });

            RestClient.Get<User>("https://highscore-db5cc.firebaseio.com/" + score4 + ".json").Then(response => {
                user4 = response;
                UpdateScore();
                UpdateName();
                Debug.Log(user4.userName);
            });

            RestClient.Get<User>("https://highscore-db5cc.firebaseio.com/" + score5 + ".json").Then(response => {
                user5 = response;
                UpdateScore();
                UpdateName();
                Debug.Log(user5.userName);
            });

            PlayerPrefs.Save();

        }

        catch(Exception e)
        {
            Debug.Log("Failed to retrieve data!");
            throw e;
        }

        PlayerPrefs.Save();

    }
}

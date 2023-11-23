using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button Level1, Level2, Level3, Scores;

    void Start()
    {
        Level1.onClick.AddListener(LoadLevel1);
        Level2.onClick.AddListener(LoadLevel2);
        Level3.onClick.AddListener(LoadLevel3);
        Scores.onClick.AddListener(LoadScores);
    }

   void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }
    void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }

    void LoadScores()
    {
        SceneManager.LoadScene(4);
    }

}

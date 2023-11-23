using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoresUI : MonoBehaviour
{
    public Button Menu;
    public TMP_Text L1Party, L2Party, L3Party, L1Boss, L2Boss, L3Boss;
    void Start()
    {
        Menu.onClick.AddListener(LoadMenu);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}

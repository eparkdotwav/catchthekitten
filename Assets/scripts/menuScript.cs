using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public Text timeText;
    int _bestTime;

    // Start is called before the first frame update
    void Start()
    {
        Display();
    }

    // Update is called once per frame
    void Update()
    {
        Display();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Main");

    }

    void Display()
    {
        _bestTime = PlayerPrefs.GetInt("best");
        timeText.text = "best time: " + _bestTime.ToString();
    }
}

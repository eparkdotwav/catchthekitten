using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class sarangScript : MonoBehaviour
{
    public Text timerText;
    public GameObject baby;

    Rigidbody2D _rbody;
    managerScript _managerScript;
    float _speed = 5;

    float _startTime;
    float _totalTime;
    bool _isPlaying;

    int _bestTime;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _managerScript = GameObject.FindObjectOfType<managerScript>();
        _startTime = Time.time;
        _totalTime = 0;
        _isPlaying = true;

        _bestTime = 0;

        if (PlayerPrefs.HasKey("best"))
        {
            _bestTime = PlayerPrefs.GetInt("best");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlaying)
        {
            float currentTime = Time.time;
            _totalTime = currentTime - _startTime;

            timerText.text = "time: " + MathF.Round(_totalTime);

            AxisControl();

            CheckQuit();
        }

        if (!_isPlaying)
        {
            if (_totalTime < _bestTime || _bestTime == 0)
            {
                PlayerPrefs.SetInt("best", (int)_totalTime);
                timerText.text = "new best time!!";
            }
            _managerScript.kittenFound();
        }
    }

    void AxisControl()
    {
        // base direction vector
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");
        Vector2 direction = (new Vector2(xDir, yDir)).normalized;
        // set direction based on direction
        _rbody.velocity = direction.normalized * _speed;
    }

    void CheckQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kitten"))
        {
            _isPlaying = false;
            baby.SetActive(true);

        }
    }
}

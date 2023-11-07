using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerScript : MonoBehaviour
{
    public GameObject explosion;
    public GameObject kitten;
    private void Update()
    {
       
    }

    void ChangeScreen()
    {
        SceneManager.LoadScene("Menu");
    }

    public void kittenFound()
    {
        explosion.SetActive(true);
        
        Invoke("ChangeScreen", 2);
    }
}
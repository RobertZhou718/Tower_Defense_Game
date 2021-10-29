using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour
{

    public GameObject menu;
    public GameObject result;
    void Start()
    {
      
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Playagain1 (){

        result.SetActive(false);
        SceneManager.LoadScene(1);
      

    }
    public void Playagain2()
    {
        SceneManager.LoadScene(2);
        result.SetActive(false);

    }
    public void Playagain3()
    {
        SceneManager.LoadScene(3);
        result.SetActive(false);

    }
    public void Playagain4()
    {
        SceneManager.LoadScene(4);
        result.SetActive(false);

    }
    public void next1() {
        SceneManager.LoadScene(2);
       

    }
    public void next2()
    {
        SceneManager.LoadScene(3);
      
    }
    public void next3()
    {
        SceneManager.LoadScene(4);
       
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
      
    }
    public void Pause()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }
    public void countinue() {

        Time.timeScale = 1;
        menu.SetActive(false);

    }

}

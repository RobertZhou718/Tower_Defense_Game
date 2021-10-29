using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Result : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;
    public GameObject result;
    public Button next;
    public AudioSource win1;
    public AudioSource lose1;



    // Start is called before the first frame update
    void Start()
    {
       result.SetActive(false);
        Enemymovement.lose = false;
    }

    // Update is called once per frame
    void Update()
    {
    

        if (Generate.Num == 0)
        {
            win1.Play();      
            result.SetActive(true);
            win.SetActive(true);
            lose.SetActive(false);
          
            Transition.win1 = true;        
        }
        if (Enemymovement.lose) {
            lose1.Play();
            Enemymovement.lose = false;
            result.SetActive(true);
            win.SetActive(false);
            lose.SetActive(true);
       
            next.interactable = false;
        }
    }
}

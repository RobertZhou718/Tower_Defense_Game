using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    public Image[] arrow;
    public Text[] subtitle;
    public static bool guide;
    public static Guide instance;

     void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        guide = true;
        Invoke("tutorial",0.5f);
        arrow[0].gameObject.SetActive(false);
        arrow[1].gameObject.SetActive(false);
        arrow[2].gameObject.SetActive(false);
        subtitle[0].gameObject.SetActive(false);
        subtitle[1].gameObject.SetActive(false);
        subtitle[2].gameObject.SetActive(false);
        subtitle[3].gameObject.SetActive(false);
        subtitle[4].gameObject.SetActive(false);
    }
    public void tutorial() {
        Time.timeScale = 0;
        subtitle[0].gameObject.SetActive(true);
        subtitle[1].gameObject.SetActive(true);
        arrow[0].gameObject.SetActive(true);
        arrow[1].gameObject.SetActive(false);
        arrow[2].gameObject.SetActive(false);
    }
    public void skip() { 
    
    }
    public void step1() {
        if (guide)
        {
            subtitle[0].gameObject.SetActive(false);
            subtitle[1].gameObject.SetActive(false);
            arrow[0].gameObject.SetActive(false);
            arrow[1].gameObject.SetActive(true);
            subtitle[2].gameObject.SetActive(true);
        }      
    }
    public void step2() {
        if (guide)
        {
            subtitle[2].gameObject.SetActive(false);
            arrow[1].gameObject.SetActive(true);            
            subtitle[3].gameObject.SetActive(true);
        }
    }
    public void step3() {
        if (guide)
        {
            arrow[1].gameObject.SetActive(false);
            arrow[2].gameObject.SetActive(true);
            subtitle[3].gameObject.SetActive(false);
            subtitle[4].gameObject.SetActive(true);
        }
    }
    public void step4() {
        if (guide)
        {
            arrow[0].gameObject.SetActive(false);
            arrow[1].gameObject.SetActive(false);
            arrow[2].gameObject.SetActive(false);
            subtitle[0].gameObject.SetActive(false);
            subtitle[1].gameObject.SetActive(false);
            subtitle[2].gameObject.SetActive(false);
            subtitle[3].gameObject.SetActive(false);
            subtitle[4].gameObject.SetActive(false);
            Time.timeScale = 1;
            guide = false;
        }
    }
}

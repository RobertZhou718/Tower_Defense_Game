using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Generate : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Result;
    public GameObject win;
    public GameObject lose;
    public int amount1;
    public int amount2;
    public int amount3;
    public float sec = 1f;
    public float generategap1 = 2f;
    public float generategap2 = 3f;
    public Vector3 GeneratePosition1;
    public Vector3 GeneratePosition2;
    public static int Wave1Num;
    public static int Wave2Num;
    public static int Wave3Num3;
    private string waveState;
    private bool generating;
    public static bool wave3 = false;
    public AudioSource win1;
    public AudioSource lose1;
    // Start is called before the first frame update
    void Start()
    {
        Result.SetActive(false);
        Wave1Num = amount1;
        Wave2Num = -1;
        Wave3Num3 = -1;
        generategap1 = 2f;
        generategap2 = 3f;
        generating = true;
        Enemymovement.lose = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (waveState)
        {
            case "NO1":
                GenerateEnemies(GeneratePosition1, Enemy1, ref amount1, ref generategap1);
                break;
            case "NO2":
                GenerateEnemies(GeneratePosition2, Enemy2, ref amount2, ref generategap2);
             
                break;
            case "NO3":
                GenerateEnemies(GeneratePosition1, Enemy1, ref amount3, ref generategap1);
                GenerateEnemies(GeneratePosition2, Enemy2, ref amount3, ref generategap2);

                break;
            default:
                break;
        }

        if (Wave1Num > 0 && Wave2Num <= 0)
        {
            if (generating == false) return;
            waveState = "NO1";
            Wave2Num = amount2;
        } else if (Wave1Num <= 0 && Wave2Num > 0)
        {
            if (generating == false) return;
            waveState = "NO2";
            Wave3Num3 = amount3;
        } else if (Wave2Num <= 0 && Wave3Num3 > 0)
        {
            
            if (generating == false) return;
            waveState = "NO3";

            wave3 = true;
        }
        CheckWin();
        CheckLose();


    }

    void StopGenerate()
    {
        generating = false;
    }
    
    void CheckWin()
    {
        if (Wave1Num <= 0 && Wave2Num <= 0 && Wave3Num3 <= 0)
        {
            win1.Play();
            Result.SetActive(true);
            win.SetActive(true);
            lose.SetActive(false);
            Transition.win2 = true;
            Time.timeScale = 0;
        }
    }
    void CheckLose() {
        if (Enemymovement.lose) {
            Enemymovement.lose = false;
            lose1.Play();
            Result.SetActive(true);
            win.SetActive(false);
            lose.SetActive(true);
            Time.timeScale = 0;
        }
    }



    void GenerateEnemies(Vector3 gate, GameObject enemy, ref int amount, ref float gapTimer)
    {
        if (generating == false) return;
        gapTimer -= Time.deltaTime;
        if (gapTimer < 0)
        {
            if (amount > 0)
            {
                GameObject obj = (GameObject)Instantiate(enemy);
                
                obj.transform.position = gate;
                amount--;
                
            }
            gapTimer = 2;
        }

    }
}

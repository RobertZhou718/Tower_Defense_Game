using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Generate : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Result;
    public GameObject win;
    public GameObject lose;
    public int amount1;
    public int amount2;
    public int amount3;
    public int amount4;
    public float generategap1;
    public float generategap2;
    public float generategap3;
    public Vector3 GeneratePosition1;
    public Vector3 GeneratePosition2;
    public Vector3 GeneratePosition3;
    public static int Wave1Num;
    public static int Wave2Num;
    public static int Wave3Num;
    public static int Wave4Num;
    private string waveState;
    private bool generating;
    public static bool wave4 = false;
    public AudioSource win1;
    public AudioSource lose1;
    // Start is called before the first frame update
    void Start()
    {
        Result.SetActive(false);
        Wave1Num = amount1;
        Wave2Num = -1;
        Wave3Num = -1;
        Wave4Num = -1;
        generategap1 = 2f;
        generategap2 = 3f;
        generategap3 = 3f;
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
                GenerateEnemies(GeneratePosition3, Enemy3, ref amount3, ref generategap3);

                break;
            case "NO4":
                GenerateEnemies(GeneratePosition1, Enemy1, ref amount4, ref generategap1);
                GenerateEnemies(GeneratePosition2, Enemy2, ref amount4, ref generategap2);
                GenerateEnemies(GeneratePosition3, Enemy3, ref amount4, ref generategap3);
                break;
            default:
                break;
        }

        if (Wave1Num > 0 && Wave2Num <= 0)
        {
            if (generating == false) return;
            waveState = "NO1";
            Wave2Num = amount2;
        }
        else if (Wave1Num <= 0 && Wave2Num > 0)
        {
            if (generating == false) return;
            waveState = "NO2";
            Wave3Num = amount3;
        }
        else if (Wave1Num <= 0 && Wave2Num <= 0 && Wave3Num > 0) {
            if (generating == false) return;
            waveState = "NO3";
            Wave4Num = amount4;
        }
        else if (Wave3Num <= 0 && Wave4Num > 0)
        {

            if (generating == false) return;
            waveState = "NO4";
            wave4 = true;
        }
      

         CheckWin();
         CheckLose();

        
    }
    
    void CheckWin()
    {
        if (Wave1Num <= 0 && Wave2Num <= 0 && Wave3Num <= 0 && Wave4Num <=0)
        {
            win1.Play();
            Result.SetActive(true);
            win.SetActive(true);
            lose.SetActive(false);
            Transition.win3 = true;
            Time.timeScale = 0;
        }
    }
    void CheckLose()
    {
        if (Enemymovement.lose)
        {
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

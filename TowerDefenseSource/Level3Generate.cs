using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Generate : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Result;
    public GameObject win;
    public GameObject lose;
    public float generategap1;
    public float generategap2;
    public float generategap3;
    public Vector3 GeneratePosition1;
    public Vector3 GeneratePosition2;
    public Vector3 GeneratePosition3;
    public int amount;
    public static int Wave1Num;
    public static int Wave2Num;
    public static int Wave3Num;
    public static bool Level3 = false;
    public AudioSource win1;
    public AudioSource lose1;
    // Start is called before the first frame update
    void Start()
    {
        Result.SetActive(false);
        Level3 = true;
        Wave1Num = amount;
        Wave2Num = amount;
        Wave3Num = amount;
        Enemymovement.lose = false;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateEnemies(GeneratePosition1, Enemy1, ref amount, ref generategap1);
        GenerateEnemies(GeneratePosition2, Enemy2, ref amount, ref generategap2);
        GenerateEnemies(GeneratePosition3, Enemy3, ref amount, ref generategap3);

        CheckWin();
        CheckLose();
    }
    void CheckWin()
    {
        if (Wave1Num <= 0 && Wave2Num <= 0 && Wave3Num <= 0 )
        {
            win1.Play();
            Result.SetActive(true);
            win.SetActive(true);
            lose.SetActive(false);
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

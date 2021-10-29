using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject Enemy;
    public int amount;
    public float generategap = 1f;
    public Vector3 GeneratePosition;
    public static int Num;
    void Start()
    {
        Num = amount;
    }
    void Update()
    {
     
        generategap -= Time.deltaTime;
        
        if (generategap <= 0)
        {
            if (amount > 0)
            {
                GameObject obj = (GameObject)Instantiate(Enemy);
                obj.transform.position = GeneratePosition;
                amount--;
            }
            generategap = 2;
        }


    }
}

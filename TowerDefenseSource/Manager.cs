using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    private GameObject Turret;
    public GameObject turret1prefab;
    public GameObject turret2prefab;
    public GameObject turret1Up;
    public GameObject turret2Up;
    public List<GameObject> Upgrade;

    private SetPlace chosensquare;
    public UpgradeSellUI ui;

    void Awake()
    {
        instance = this;  
        
    }
    public GameObject Getturret()
    {
        return Turret;
    }
    public void Setturret(GameObject turret) {
 
        Turret = turret;
        chosensquare = null;

        ui.Hide();
    }
    public void ChosenSquare(SetPlace square) {
        if (chosensquare == square) {
            chosensquare = null;
            ui.Hide();
            return;
        }      
        chosensquare = square;
        Turret = null;
        ui.SetTarget(square);
    }




}

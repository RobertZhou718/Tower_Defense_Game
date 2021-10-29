using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlace : MonoBehaviour
{
    private GameObject Turret;
    private MeshRenderer MR;
    private Color Default;
    public Color Covercolor;
    Manager manager;
    public bool isguide;
    // Start is called before the first frame update
    void Start()
    {
        manager = Manager.instance;
        MR = GetComponent<MeshRenderer>();
        Default = MR.material.color;
    }
    void OnMouseDown()
    {
        if (Turret != null)
        {
            Guide.instance.step3();
            Shop.Currentturret = Turret;
            Shop.tile = this;
            Manager.instance.ChosenSquare(this);
            return;
        }
        if (manager.Getturret() != null) {
            GameObject turret = manager.Getturret();

            if (turret != null)
                Turret = (GameObject)Instantiate(turret, transform.position, transform.rotation);
            if (turret == manager.turret1prefab)
            {
                Shop.instance.Currentmoney -= 100;
            }
            else if (turret == manager.turret2prefab)
            {
                Shop.instance.Currentmoney -= 200;
            }
            manager.Setturret(null);
        }
        if (isguide){
            Guide.instance.step2();
        }
        
    }
    public void Upgradeturret(GameObject newturret) {
        Destroy(Turret);
        Turret = (GameObject)Instantiate(newturret, transform.position, transform.rotation);
        Shop.instance.Currentmoney -= 100;
    }
    public void Sell() {
        Shop.instance.Currentmoney += Turret.GetComponent<Turret>().value;
        Destroy(Turret);
    }
    void OnMouseEnter()
    {
        if (manager.Getturret() == null)
        {
            return;
        }
        MR.material.color = Covercolor;
    }
     void OnMouseExit()
    {
        MR.material.color = Default;
    }
}

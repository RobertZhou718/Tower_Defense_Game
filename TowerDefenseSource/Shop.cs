using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public static GameObject Currentturret;
    public static SetPlace tile;
    public int Currentmoney;
    private float sec = 1f;
    public Text Money;
    public Text Turrt1Cost;
    public Text Turrt2Cost;
    Manager manager;
    public UpgradeSellUI ui;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = Manager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        sec -= Time.deltaTime;
        if (sec < 0) {
            sec = 1;
            Currentmoney += 1;
        }
        if (Currentmoney > -1) {
           Money.text = "$ " + Currentmoney;
        }
        if (Currentmoney >= 100) {
            Turrt1Cost.color = Color.yellow;
        }
        if (Currentmoney >= 200) {
            Turrt2Cost.color = Color.yellow;
        }
        if (Currentmoney < 200) {
            Turrt2Cost.color = Color.red;
            if (Currentmoney < 100) {
                Turrt1Cost.color = Color.red;
            }

        }

    }
    public void BuyTurret1() {
        if (Currentmoney >= 100)
        {
            manager.Setturret(manager.turret1prefab);
           
        }
        else {
          
        }
       
    }
    public void BuyTurret2()
    {
        if (Currentmoney >= 200)
        {
           
            manager.Setturret(manager.turret2prefab);
        }
        else {
            
        }
}
    public void UpdateTurret()
    {
        if(Currentmoney >= 100) {

            manager.ChosenSquare(tile);
            if (tile == null)
                return;
            foreach (GameObject turret in manager.Upgrade)
            {
                if (Currentturret == null)
                {
                    return;
                }
                if (turret.tag == Currentturret.tag)
                {
                    tile.Upgradeturret(turret);
                    tile = null;
                }
            }
        }
       
        
    }
    public void Sell() {
        tile.Sell();
        ui.Hide();
    }


}

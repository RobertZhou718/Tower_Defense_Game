using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSellUI : MonoBehaviour
{   
    public GameObject ui;
    private SetPlace Target;
    public Button upgrade;
    public void SetTarget(SetPlace target){
        Target = target;
        transform.position =new Vector3(target.transform.position.x, target.transform.position.y + 10, target.transform.position.z);
        ui.SetActive(true);
        if (Shop.Currentturret.GetComponent<Turret>().level == 2)
        {
            upgrade.interactable = false;
        }
        else {
            upgrade.interactable = true;
        }
    }
    public void Hide() {
        ui.SetActive(false);
    }
}

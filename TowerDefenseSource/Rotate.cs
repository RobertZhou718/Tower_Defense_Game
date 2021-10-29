using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rotate : MonoBehaviour
{
	public GameObject[] Goblins;
	public GameObject Canvas1;
	public GameObject Canvas2;
	public Button L1;
	public Button L2;
	public Button L3;
	public Button L4;
	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1;
		Canvas1.SetActive(true);
		Canvas2.SetActive(false);
		L1.interactable = true;
		L2.interactable = false;
		L3.interactable =false;
		L4.interactable =false;

	}

	// Update is called once per frame
	void Update()
	{

        Goblins[0].transform.RotateAround(Vector3.up, Time.deltaTime);
		Goblins[1].transform.RotateAround(Vector3.up, Time.deltaTime);
		Goblins[2].transform.RotateAround(Vector3.up, Time.deltaTime);
		Goblins[3].transform.RotateAround(Vector3.up, Time.deltaTime);
		Goblins[4].transform.RotateAround(Vector3.up, -Time.deltaTime);
		Goblins[5].transform.RotateAround(Vector3.up, Time.deltaTime);
		Goblins[6].transform.RotateAround(Vector3.up, -Time.deltaTime);



		if (Transition.win1)
			L2.interactable = true;
		if(Transition.win2)
			L3.interactable = true;
		if (Transition.win3)
			L4.interactable = true;



	}

	public void Exit() {
		Application.Quit();
	}
	public void Play() {
		Canvas1.SetActive(false);
		Canvas2.SetActive(true);
	}
	public void Back() {
		Canvas1.SetActive(true);
		Canvas2.SetActive(false);
	}
	public void Tutorial() {
		SceneManager.LoadScene(1);
	}
	public void LV1()
	{
		SceneManager.LoadScene(2);
	}
	public void LV2()
	{
		SceneManager.LoadScene(3);
	}
	public void LV3()
	{
		SceneManager.LoadScene(4);
	}
}

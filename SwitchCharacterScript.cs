using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchCharacterScript : MonoBehaviour
{

	// referenses to controlled game objects
	public GameObject avatar1;
	public GameObject avatar2;
	public GameObject avatar3; 
	public GameObject avatar4;



	// Use this for initialization
	void Start()
	{

		// anable first avatar and disable another one
		if (PlayerPrefs.GetInt("Avatar", 1) == 1)
		{
			avatar1.gameObject.SetActive(true);
			avatar2.gameObject.SetActive(false);
			avatar3.gameObject.SetActive(false);
			avatar4.gameObject.SetActive(false);
		}
		else if (PlayerPrefs.GetInt("Avatar", 1) == 2)
		{
			avatar1.gameObject.SetActive(false);
			avatar2.gameObject.SetActive(true);
			avatar3.gameObject.SetActive(false);
			avatar4.gameObject.SetActive(false);
		}
		else if (PlayerPrefs.GetInt("Avatar", 1) == 3)
		{
			avatar1.gameObject.SetActive(false);
			avatar2.gameObject.SetActive(false);
			avatar3.gameObject.SetActive(true);
			avatar4.gameObject.SetActive(false);
		}
		else if (PlayerPrefs.GetInt("Avatar", 1) == 4)
		{
			avatar1.gameObject.SetActive(false);
			avatar2.gameObject.SetActive(false);
			avatar3.gameObject.SetActive(false);
			avatar4.gameObject.SetActive(true);
		}

	}

	// public method to choose avatars by pressing button in options
	public void ChooseAvatar1()
	{
		avatar1.gameObject.SetActive(true);
		avatar2.gameObject.SetActive(false);
		avatar3.gameObject.SetActive(false);
		avatar4.gameObject.SetActive(false);
		PlayerPrefs.SetInt("Avatar", 1);
	}
	public void ChooseAvatar2()
	{
		avatar1.gameObject.SetActive(false);
		avatar2.gameObject.SetActive(true);
		avatar3.gameObject.SetActive(false);
		avatar4.gameObject.SetActive(false);
		PlayerPrefs.SetInt("Avatar", 2);
	}
	public void ChooseAvatar3()
	{
		avatar1.gameObject.SetActive(false);
		avatar2.gameObject.SetActive(false);
		avatar3.gameObject.SetActive(true);
		avatar4.gameObject.SetActive(false);
		PlayerPrefs.SetInt("Avatar", 3);
	}
	public void ChooseAvatar4()
	{
		avatar1.gameObject.SetActive(false);
		avatar2.gameObject.SetActive(false);
		avatar3.gameObject.SetActive(false);
		avatar4.gameObject.SetActive(true);
		PlayerPrefs.SetInt("Avatar", 4);
	}


}

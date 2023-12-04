using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public GameObject ui_window;
	public Text textField;
	
	public void ToggleUI(bool setActive)
	{
		ui_window.SetActive(setActive);
	}

	public void ShowText(string text)
	{
		ToggleUI(true);
		textField.text = text;
	}
}

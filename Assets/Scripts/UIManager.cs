using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public Text time;
	public Text level;
	public Image key;
	int minutes = 0;
	int seconds = 0;
	int levelNumber = 1;
	bool gotKey = false;

	void Update () 
	{
		seconds = (int)Time.time;
		minutes = seconds / 60;

		if(seconds%60 < 10)
		{
			time.text = minutes + ":0" + seconds%60;
		}
		else
		{
			time.text = minutes + ":" + seconds%60;
		}
		level.text = "Level " + levelNumber;

		if(gotKey == true)
		{
			key.GetComponent<Image>().enabled = true;
		}
		else
		{
			key.GetComponent<Image>().enabled = false;
		}
	}
}

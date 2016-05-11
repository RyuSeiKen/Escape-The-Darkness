using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public Text time;
<<<<<<< HEAD
	[HideInInspector]
	public int a = 0;
	[HideInInspector]
	public int b = 0;
=======
	public Text level;
	public Image key;
	int minutes = 0;
	int seconds = 0;
	int levelNumber = 1;
	bool gotKey = false;
>>>>>>> c792294d1477a7f0175cda6106156b671eb6824e

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

using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public GameObject[,] _Dungeon;

	int DungeonLength = 21;
	int DungeonWidth = 21;

	// Use this for initialization
	void Awake () 
	{
		_Dungeon = new GameObject[DungeonLength, DungeonWidth];
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}

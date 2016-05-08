using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	[HideInInspector]
	public GameObject[,] _Dungeon;
	int DungeonLength = 20;
	int DungeonWidth = 20;

	// Use this for initialization
	void Start () 
	{
		_Dungeon = new GameObject[DungeonLength, DungeonWidth];
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonGenerator : MonoBehaviour {

	public GameObject _StartRoom;

	GameObject GameManager;
	GridManager Grid;

	List<GameObject> NewRooms = new List<GameObject>();
	List<GameObject> InstantiateRooms = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
		GameManager = GameObject.FindGameObjectWithTag ("Manager");
		Grid = GameManager.GetComponent<GridManager> ();

		GameObject NewRoom = Instantiate (_StartRoom) as GameObject;

		Grid._Dungeon [11, 11] = NewRoom;

		Room RoomProperties = NewRoom.GetComponent<Room> ();
		RoomProperties.Xpos = 11;
		RoomProperties.Ypos = 11;

		NewRooms.Add (NewRoom);



	}

	void Generation() 
	{
		foreach (GameObject _NewRoom in NewRooms) 
		{
			GameObject ActiveRoom = _NewRoom;
			RoomGenerator(ActiveRoom);
		}

		ListeTransfert ();
	}

	void RoomGenerator(GameObject _UseRoom) 
	{
		
		Room RoomProperties = _UseRoom.GetComponent<Room> ();

		if (RoomProperties._upAvailable == true) 
		{
			CreateRoom (1, _UseRoom);
		}

		if (RoomProperties._downAvailable == true) 
		{
			CreateRoom (2, _UseRoom);
		}

		if (RoomProperties._leftAvailable == true) 
		{
			CreateRoom (3, _UseRoom);
		}

		if (RoomProperties._rightAvailable == true) 
		{
			CreateRoom (4, _UseRoom);
		}


	}

	void CreateRoom(int side, GameObject CurrentRoom)
	{
		
		Room CurrentRoomProperties = CurrentRoom.GetComponent<Room> ();
		int CurrentRoomX = CurrentRoomProperties.Xpos;
		int CurrentRoomY = CurrentRoomProperties.Ypos;

		
		switch(side) 
		{
		case 1:
			if (Grid._Dungeon [CurrentRoomX, CurrentRoomY + 1] == null) 
			{
				GameObject NextRoomUp = Instantiate (_StartRoom) as GameObject;
			
				InstantiateRooms.Add (NextRoomUp);

				Grid._Dungeon [CurrentRoomX, CurrentRoomY + 1] = NextRoomUp;


				Room NextRoomUpProperties = NextRoomUp.GetComponent<Room> ();
				NextRoomUpProperties._downAvailable = false;
				NextRoomUpProperties.Xpos = CurrentRoomX;
				NextRoomUpProperties.Ypos = CurrentRoomY + 1;

				NextRoomUp.transform.position = CurrentRoom.transform.position + new Vector3 (0, 10, 0);
			} else {}

			break;

		case 2:
			if (Grid._Dungeon [CurrentRoomX, CurrentRoomY - 1] == null) {
				GameObject NextRoomDown = Instantiate (_StartRoom) as GameObject;

				InstantiateRooms.Add (NextRoomDown);

				Grid._Dungeon [CurrentRoomX, CurrentRoomY - 1] = NextRoomDown;

				Room NextRoomDownProperties = NextRoomDown.GetComponent<Room> ();
				NextRoomDownProperties._upAvailable = false;
				NextRoomDownProperties.Xpos = CurrentRoomX;
				NextRoomDownProperties.Ypos = CurrentRoomY - 1;

				NextRoomDown.transform.position = CurrentRoom.transform.position + new Vector3 (0, -10, 0);
			} else {}
				
			break;

		case 3:
			if (Grid._Dungeon [CurrentRoomX - 1, CurrentRoomY] == null) {				
				GameObject NextRoomLeft = Instantiate (_StartRoom) as GameObject;

				InstantiateRooms.Add (NextRoomLeft);

				Grid._Dungeon [CurrentRoomX - 1, CurrentRoomY] = NextRoomLeft;

				Room NextRoomLeftProperties = NextRoomLeft.GetComponent<Room> ();
				NextRoomLeftProperties._rightAvailable = false;
				NextRoomLeftProperties.Xpos = CurrentRoomX - 1;
				NextRoomLeftProperties.Ypos = CurrentRoomY;

				NextRoomLeft.transform.position = CurrentRoom.transform.position + new Vector3 (-10, 0, 0);
			} else {}

			break;

		case 4:
			if (Grid._Dungeon [CurrentRoomX + 1, CurrentRoomY] == null) {
				GameObject NextRoomRight = Instantiate (_StartRoom) as GameObject;

				InstantiateRooms.Add (NextRoomRight);
				Grid._Dungeon [CurrentRoomX + 1, CurrentRoomY] = NextRoomRight;

				Room NextRoomRightProperties = NextRoomRight.GetComponent<Room> ();
				NextRoomRightProperties._leftAvailable = false;
				NextRoomRightProperties.Xpos = CurrentRoomX + 1;
				NextRoomRightProperties.Ypos = CurrentRoomY;

				NextRoomRight.transform.position = CurrentRoom.transform.position + new Vector3 (10, 0, 0);
			} else {}

			break;
		}

	}

	void ListeTransfert() 
	{
		NewRooms.Clear ();
		foreach (GameObject Rooms in InstantiateRooms) 
		{
			NewRooms.Add (Rooms);
		}
		InstantiateRooms.Clear ();
	}


	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Generation ();
		}
	}
}

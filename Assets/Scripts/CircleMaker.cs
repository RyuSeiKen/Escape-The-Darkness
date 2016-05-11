using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CircleMaker : MonoBehaviour
{
	public GameObject prefab;
	public GameObject room;
	Material material;
	Material oldMaterial;
	Transform currentBottomLeft;


	void Update ()
	{
		float radius = 5f;
		GameObject trail = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
		trail.transform.rotation = room.transform.rotation;
		material = trail.GetComponent<Renderer>().material;
		material.SetFloat("_Radius", radius); // just in case you want to use it
//		material.SetFloat("_OffsetX", LocationInRoom().x);
//		material.SetFloat("_OffsetY", LocationInRoom().y);
	}

	Vector2 LocationInRoom()
	{
		foreach(Transform child in room.transform)
		{
			if(child.tag == "BottomLeft")
			{
				currentBottomLeft = child;
			}
		}
		float x = (transform.position.x - currentBottomLeft.position.x) / (100);
		float y = (transform.position.y - currentBottomLeft.position.y) / (100);
		return new Vector2(x, y);
	}
}
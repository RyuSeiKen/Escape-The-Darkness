using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CircleMaker : MonoBehaviour
{
	float frequency = 1.0f;
	float amplitudeMin = 0.08f;
	float amplitudeMax = 0.12f;
	float feather = 0.1f;
	public GameObject room1;
	GameObject room;
	Material material;
	Material oldMaterial;
	Vector2 pos;
	Transform currentBottomLeft;
	Transform currentTopRight;


	void Update ()
	{
		LocationInRoom();
		float amplitudeCenter = (amplitudeMax + amplitudeMin) * 0.5f;
		float amplitudeDeviation = (amplitudeMax - amplitudeMin) * 0.5f;
		float radius = Mathf.Sin(2.0f * Mathf.PI * frequency * Time.time) * amplitudeDeviation + amplitudeCenter;

		material.SetFloat("_Radius", radius);
		material.SetFloat("_InnerRadius", radius - feather * 0.5f);
		material.SetFloat("_OuterRadius", radius + feather * 0.5f);
	}

	void OnCollisionEnter(Collision col)
	{
		oldMaterial = material;
		room = col.collider.gameObject;
		material = room.GetComponent<Renderer>().material;

		oldMaterial.SetFloat("_Radius", 0);
		oldMaterial.SetFloat("_InnerRadius", 0);
		oldMaterial.SetFloat("_OuterRadius", 0);
	}

	void LocationInRoom()
	{
		foreach(Transform child in room.transform)
		{
			if(child.tag == "BottomLeft")
			{
				currentBottomLeft = child;
			}
			else if(child.tag == "TopRight")
			{
				currentTopRight = child;
			}
		}
		float x = (transform.position.x - currentBottomLeft.position.x) / (2 * currentTopRight.position.x);
		float y = (transform.position.y - currentBottomLeft.position.y) / (2 * currentTopRight.position.y);
		pos = new Vector2(x, y);
		Debug.Log(pos);
	}
}
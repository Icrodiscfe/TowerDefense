using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour {
	[SerializeField]
	private float size = 1f;
	[SerializeField]
	private int sizeX = 20;
	[SerializeField]
	private int sizeZ = 20;
	[SerializeField]
	private Color color;

	public Vector3 GetNearestPointOnGrid(Vector3 position)
	{
		position -= transform.position;

		int xCount = Mathf.Clamp(Mathf.RoundToInt(position.x / size), 0, sizeX);
		int yCount = 0; //Mathf.RoundToInt(position.y); //Mathf.RoundToInt(position.y / size);
		int zCount = Mathf.Clamp(Mathf.RoundToInt(position.z / size), 0 , sizeZ);

		Vector3 result = new Vector3(
			(float)xCount * size,
			(float)yCount * size,
			(float)zCount * size);

		result += transform.position;

		return result;
	}

	private void OnDrawGizmos()
	{
		var posX = transform.position.x;
		var posY = transform.position.y;
		var posZ = transform.position.z;
		Gizmos.color = color;
		for (float x = 0; x <= sizeX * size; x += size)
		{
			for (float z = 0; z <= sizeZ * size; z += size)
			{
				var point = GetNearestPointOnGrid(new Vector3(posX + x, posY, posZ + z));
				Gizmos.DrawSphere(point, 0.1f);
			}

		}
	}
}

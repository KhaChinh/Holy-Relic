using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PathwayInspector : MonoBehaviour
{
	// Spawn point of this pathway
	public SpawnPoint spawnPoint;
	// Prefab for waypoint
	public Waypoint waypointPrefab;
	// Waypoint folder for this pathway
	public Transform waypointsFolder;
	// Waypoint offset when placed on scene
	public Vector2 offset = new Vector2(1f, 0f);

	void OnEnable()
	{
		Debug.Assert(spawnPoint && waypointPrefab && waypointsFolder, "Wrong stuff settings");
	}

	public GameObject GetSpawnPoint()
	{
		return spawnPoint.gameObject;
	}

	public GameObject AddWaypoint()
	{
		Waypoint[] array = GetComponentsInChildren<Waypoint>();
		GameObject res = Instantiate(waypointPrefab, waypointsFolder).gameObject;
		res.transform.SetAsLastSibling();
		res.name = waypointPrefab.name + " (" + (array.Length + 1) + ")";
		if (array.Length > 0)
		{
			res.transform.position = array[array.Length - 1].transform.position + (Vector3)offset;
		}
		else
		{
			res.transform.position += (Vector3)offset;
		}
		return res;
	}

	public GameObject GetNextWaypoint(GameObject currentSelected)
	{
		return InspectorsUtil<Waypoint>.GetNext(waypointsFolder, currentSelected);
	}

	public GameObject GetPrevioustWaypoint(GameObject currentSelected)
	{
		return InspectorsUtil<Waypoint>.GetPrevious(waypointsFolder, currentSelected);
	}
}

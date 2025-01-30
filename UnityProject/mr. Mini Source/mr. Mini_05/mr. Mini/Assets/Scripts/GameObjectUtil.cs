using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUtil {

	private static Dictionary<RecycleGameObjects, ObjectsPool> pools = new Dictionary<RecycleGameObjects, ObjectsPool> ();

	//=========================================================================================
	public static GameObject Instantiate(GameObject prefab, Vector3 pos){
		GameObject instance = null;

		var recycledScript = prefab.GetComponent<RecycleGameObjects> ();
		if (recycledScript != null) {
			var pool = GetObjectPool (recycledScript);
			instance = pool.NextObject (pos).gameObject;
		} else {
			instance = GameObject.Instantiate (prefab);
			instance.transform.position = pos;
		}
		return instance;
	}

	//=========================================================================================
	public static void Destroy(GameObject gameObject){

		var recycleGameObject = gameObject.GetComponent<RecycleGameObjects> ();

		if (recycleGameObject != null) {
			recycleGameObject.ShutDown ();
		} else {
			GameObject.Destroy (gameObject);
		}
	}

	//=========================================================================================
	private static ObjectsPool GetObjectPool(RecycleGameObjects reference){
		ObjectsPool pool = null;

		if (pools.ContainsKey (reference)) {
			pool = pools [reference];
		} else {
			var poolContainer = new GameObject (reference.gameObject.name + "ObjectsPool");
			pool = poolContainer.AddComponent<ObjectsPool> ();
			pool.prefab = reference;
			pools.Add (reference, pool);
		}

		return pool;
	}
}

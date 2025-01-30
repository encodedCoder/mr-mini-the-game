using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectsPool : MonoBehaviour {

	public RecycleGameObjects prefab;

	private List<RecycleGameObjects> poolInstances = new List<RecycleGameObjects> ();

	//=====================================================
	private RecycleGameObjects CreatInstances(Vector3 pos){

		var clone = GameObject.Instantiate (prefab);
		clone.transform.position = pos;
		clone.transform.parent = transform;

		poolInstances.Add (clone);

		return clone;
	}

	//=====================================================
	public RecycleGameObjects NextObject (Vector3 pos){
		RecycleGameObjects instance = null;

		foreach (var gameObj in poolInstances) {
			if (gameObj.gameObject.activeSelf != true) {
				instance = gameObj;
				instance.transform.position = pos;
			}
		}

		if (instance == null) {
			instance = CreatInstances (pos);
		}

		instance.Restart ();

		return instance;
	}
}

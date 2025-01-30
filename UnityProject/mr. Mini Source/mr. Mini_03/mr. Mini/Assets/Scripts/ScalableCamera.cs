using UnityEngine;
using System.Collections;

public class ScalableCamera : MonoBehaviour {

	public static float scale = 1f;

	public Vector2 nativeRes = new Vector2(480, 270);

	void Awake(){
		var camera = GetComponent<Camera> ();
		if (camera.orthographic) {
			scale = Screen.height / nativeRes.y;
			camera.orthographicSize = (Screen.height / 2.0f) / scale;
		}
	}

}

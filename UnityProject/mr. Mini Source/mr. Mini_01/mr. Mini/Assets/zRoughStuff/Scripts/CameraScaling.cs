using UnityEngine;
using System.Collections;

public class CameraScaling : MonoBehaviour {

	public static float scale = 1f;
	public static float orthoScale = 1f;

	public static float width = 1;
	public static float height = 1;

	public Vector2 nativeResolution = new Vector2 (480, 270);

	void Awake () {
		var camera = GetComponent<Camera> ();
		if (camera.orthographic) {
			scale = Screen.height / nativeResolution.y;

			camera.orthographicSize = (Screen.height / 2.0f) / scale;
			orthoScale = camera.orthographicSize;

			width = (nativeResolution.x * scale);
			height = (nativeResolution.y * scale);
		}
	}
}

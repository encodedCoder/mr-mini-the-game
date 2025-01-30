using UnityEngine;
using System.Collections;

public class TiledMountain : MonoBehaviour {

	// Use this for initialization
	void Start () {

		var newWidth  = Mathf.Ceil (Screen.width / CameraScaling.scale);
		var newHeight = transform.localScale.y * CameraScaling.orthoScale;
		var textureSize = (Screen.width / CameraScaling.orthoScale);

		transform.localScale = new Vector3 (newWidth, newHeight, 1);

		transform.localPosition = new Vector2 (0, 25);

		GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (textureSize, 1, 1);
	}

}

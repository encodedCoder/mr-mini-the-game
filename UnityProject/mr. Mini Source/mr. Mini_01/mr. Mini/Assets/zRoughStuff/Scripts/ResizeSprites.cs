using UnityEngine;
using System.Collections;

public class ResizeSprites : MonoBehaviour {

	// Use this for initialization
	void Start () {

		var scaling =  GetComponent<Transform> ();

		var newWidth = transform.localScale.x * CameraScaling.orthoScale;
		var newHeight = transform.localScale.y * CameraScaling.orthoScale;

		scaling.localScale = new Vector3 (newWidth, newHeight, 1);

	}

}

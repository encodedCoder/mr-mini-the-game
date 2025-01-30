using UnityEngine;
using System.Collections;

public class TiledTexture : MonoBehaviour {

	public int textureSize = 128;

	// Use this for initialization
	void Start () {

		var newWidth  = Mathf.Ceil (Screen.width / (textureSize * ScalableCamera.scale));

		transform.localScale = new Vector3 (newWidth * textureSize, textureSize, 1);

		GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (newWidth, 1, 1);
	}

}

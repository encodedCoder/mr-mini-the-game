using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour, IRecyle {

	public Sprite[] sprites;

	public void Restart(){
		var renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = sprites [Random.Range (0, sprites.Length)];

		var collider = GetComponent<BoxCollider2D> ();
		collider.size = renderer.bounds.size / 30;
	}

	public void ShutDown(){

	}
}

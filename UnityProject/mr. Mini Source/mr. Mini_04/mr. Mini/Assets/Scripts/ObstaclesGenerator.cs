using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class ObstaclesGenerator : MonoBehaviour {

	public GameObject[] obstaclesPrefabs;
	public float delay = 2.0f;
	public bool active = true;
	public Vector2 delayRange = new Vector2 (1, 3);

	// Use this for initialization
	void Start () {
		ResetDelay ();
		StartCoroutine (ObjectGenerator());
	}

	IEnumerator ObjectGenerator(){
		yield return new WaitForSeconds (delay);

		if (active) {
			var newTransform = transform;

			GameObjectUtil.Instantiate (obstaclesPrefabs[Random.Range (0,obstaclesPrefabs.Length)], newTransform.position);

			ResetDelay ();
		}

		StartCoroutine (ObjectGenerator());

	}

	void ResetDelay(){
		delay = Random.Range (delayRange.x, delayRange.y);
	}
}

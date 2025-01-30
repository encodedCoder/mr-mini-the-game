using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;
	public Text continueText;
	public Text gameScoreText;
	public Text sureshGamesPresents;
	public Image logoIntro;

	private float timeElapsed = 0f;
	private float bestTime = 0f;
	private float blinkTime = 0f;
	private bool blink;
	private bool gameStarted;
	private TimeManager timeManager;
	private GameObject player;
	private GameObject ground;
	private ObstaclesGenerator objGenerator;
	private bool beatBestTime;

	void Awake(){
		ground = GameObject.Find ("Ground");
		objGenerator = GameObject.Find ("ObstaclesGenerator").GetComponent<ObstaclesGenerator> ();
		timeManager = GetComponent<TimeManager> ();
	}

	// Use this for initialization
	void Start () {
		var groundHeight = ground.transform.localScale.y;

		var pos = ground.transform.position;
		pos.x = 0;
		pos.y = -((Screen.height / ScalableCamera.scale) / 2) + (groundHeight/2) - 20;
		ground.transform.position = pos;

		objGenerator.active = false;

		Time.timeScale = 0;

		continueText.text = "PRESS ANY BUTTON TO START";
		sureshGamesPresents.text = "SURESH GAMES PRESENETS \n\nMr. Mini";

		bestTime = PlayerPrefs.GetFloat ("BestTimeS");
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted && Time.timeScale == 0) {
			if (Input.anyKeyDown) {
				timeManager.ManipulateTime (1, 1f);
				ResetGame ();
			}
		}

		if (!gameStarted) {
			blinkTime++;
			if (blinkTime % 40 == 0) {
				blink = !blink;
			}

			continueText.canvasRenderer.SetAlpha (blink ? 0 : 1);

			var textColor = beatBestTime ? "#FF0" : "#FFF";

			gameScoreText.text = "TIME: " + FormatTime (timeElapsed) + "\n<color="+textColor+">BEST: " + FormatTime (bestTime)+"</color>";
		} else {
			timeElapsed += Time.deltaTime;
			gameScoreText.text = "TIME: " + FormatTime (timeElapsed);
		}


	}
	void OnPlayerKilled(){
		objGenerator.active = false;

		var PlayerDestroyScript = player.GetComponent<DestroyOffscreen> ();
		PlayerDestroyScript.DestroyCallback -= OnPlayerKilled;

		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		timeManager.ManipulateTime (0, 5.5f);
	
		gameStarted = false;

		continueText.text = "PRESS ANY BUTTON TO RESTART";

		if (timeElapsed > bestTime) {
			bestTime = timeElapsed;
			PlayerPrefs.SetFloat ("BestTimeS", bestTime);
			beatBestTime = true;

		}

	}

	void ResetGame(){
		objGenerator.active = true;

		player = GameObjectUtil.Instantiate (playerPrefab, new Vector3 (0, Screen.height / ScalableCamera.scale / 2 + 50, 0));

		var PlayerDestroyScript = player.GetComponent<DestroyOffscreen> ();
		PlayerDestroyScript.DestroyCallback += OnPlayerKilled;

		gameStarted = true;

		continueText.canvasRenderer.SetAlpha (0);
		sureshGamesPresents.canvasRenderer.SetAlpha (0);
		logoIntro.canvasRenderer.SetAlpha (0);

		timeElapsed = 0;
		beatBestTime = false;

	}

	string FormatTime(float value){
		TimeSpan t = TimeSpan.FromSeconds (value);

		return string.Format ("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
	}
}

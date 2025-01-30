﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IRecyle{

	void Restart ();
	void ShutDown ();

}

public class RecycleGameObjects : MonoBehaviour {

	private List<IRecyle> recycleComponents;

	void Awake(){

		var components = GetComponents<MonoBehaviour> ();
		recycleComponents = new List<IRecyle> ();

		foreach (var component in components) {
			if (component is IRecyle) {
				recycleComponents.Add (component as IRecyle);
			}
		}

		//Debug.Log (name + " Found " + recycleComponents.Count + " Components");
	}

	public void Restart(){
		gameObject.SetActive (true);

		foreach (var component in recycleComponents) {
			component.Restart ();
		}
	}

	public void ShutDown(){
		gameObject.SetActive (false);

		foreach (var component in recycleComponents) {
			component.ShutDown ();
		}
	}
}

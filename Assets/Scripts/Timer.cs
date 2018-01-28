using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Timer : Activatable {

	private bool runCR = false;
	public float firstTimer;
	public float lastTimer;
	public abstract void firstAction();

	public abstract void lastAction();

	IEnumerator ToggleCoroutine() {
		while (runCR) {
			yield return new WaitForSeconds(firstTimer);
			firstAction();
			yield return new WaitForSeconds(lastTimer);
			lastAction();
		}
	}

	public void startTimer() {
		runCR = true;
		StartCoroutine(ToggleCoroutine());
	}

	public void stopTimer() {
		runCR = false;
	}
}

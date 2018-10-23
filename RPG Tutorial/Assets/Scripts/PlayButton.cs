using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {
	
	public Button button;
	void Start() {
		button.onClick.AddListener(delegate {loadNextScene("Town"); });
	}

	void Update() {
	}
	public void loadNextScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
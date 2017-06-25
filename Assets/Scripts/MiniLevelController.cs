using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniLevelController : MonoBehaviour {
	public GameObject winPrefab;
	public float afterWinTime;
	bool music, sound;
	// Use this for initialization
	void Start () {
		setInfo ();
		StartCoroutine (openWinPanel ());
	}
	
	public IEnumerator openWinPanel() {
		yield return new WaitForSeconds (afterWinTime);
		//Знайти батьківський елемент
		GameObject parent = UICamera.first.transform.parent.gameObject;
		//Створити Prefab
		GameObject obj = NGUITools.AddChild (parent, winPrefab);
		//Отримати доступ до компоненту (щоб передати параметри)
		obj.GetComponent<WinPanel>();
	}

	public void setInfo() {
		string str2 = PlayerPrefs.GetString ("MusicAndSound", null);
		MusicAndSound musicAndSound = JsonUtility.FromJson<MusicAndSound> (str2);

		if (musicAndSound != null) {
			music = musicAndSound.music;
			sound = musicAndSound.sound;
		}
	}
}

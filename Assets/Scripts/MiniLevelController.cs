using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniLevelController : MonoBehaviour {
	public GameObject winPrefab;
	public float afterWinTime;
	// Use this for initialization
	void Start () {
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
		
}

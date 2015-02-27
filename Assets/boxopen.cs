using UnityEngine;
using System.Collections;

public class boxopen : MonoBehaviour {

	public bool unopened = true;
	public starinchest star;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (unopened) {
			animation.Play("ChestAnim");
			unopened = false;
			Invoke ("EnableStar", 3.5f);
		}
	}

	void EnableStar () {
		star.gameObject.SetActive (true);
	}
}

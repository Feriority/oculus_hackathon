using UnityEngine;
using System.Collections;

public class boxopen : MonoBehaviour {

	public bool unopened = true;
	public starinchest star;
	public AudioClip boxOpenClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (unopened) {
			animation.Play("ChestAnim");
			AudioSource.PlayClipAtPoint(boxOpenClip, transform.position);
			unopened = false;
			Invoke ("EnableStar", 3.0f);

		}
	}

	void EnableStar () {
		star.gameObject.SetActive (true);
	}
}

using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	private float sineFactor = 0;

	void Start () {
		transform.Rotate(new Vector3 (0, Random.Range(0, 1), 0));
		sineFactor = Random.Range (0, (2 * Mathf.PI));
		rotate ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3 (0, 45, 0) * Time.deltaTime);
		sineFactor = (sineFactor + Time.deltaTime) % (2 * Mathf.PI);
		rotate ();
	}

	void rotate() {
		transform.Translate(new Vector3 (0, 0.01f, 0) * Mathf.Sin(sineFactor));
	}
	
}

using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {

	public Camera cameraFacing;
	private Vector3 originalScale;

	// Use this for initialization
	void Start () {
		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		float distance;
		if (Physics.Raycast (new Ray (cameraFacing.transform.position, cameraFacing.transform.rotation * Vector3.forward), out hit)) {
			distance = hit.distance;
		} else {
			distance = cameraFacing.farClipPlane * 0.95f;
		}
		transform.LookAt (cameraFacing.transform.position);
		transform.position = cameraFacing.transform.position + cameraFacing.transform.rotation * Vector3.forward * distance;
		transform.Rotate (0, 180, 0);
		if (distance < 10) {
			distance *= 1 + 5 * Mathf.Exp(-distance);
		}
		transform.localScale = originalScale * distance;
	}

	public IEnumerator FadeOut (float duration)
	{
		Material mat = GetComponentInChildren<MeshRenderer>().material;
		
		while(mat.color.a > 0)
		{
			Color newColor = mat.color;
			newColor.a -= Time.deltaTime / duration;
			mat.color = newColor;
			yield return null;
		} 
	}

	public IEnumerator FadeIn (float duration)
	{
		Material mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
		
		while(mat.color.a < 255)
		{
			Color newColor = mat.color;
			newColor.a += Time.deltaTime / duration;
			mat.color = newColor;
			yield return null;
		} 
	}
}

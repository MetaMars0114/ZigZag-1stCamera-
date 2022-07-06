using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Initialize variables.
	[SerializeField]
	Transform target;

	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = target.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		// If the player hasn't fallen off the platform, follow him.
		if (target.gameObject.GetComponent<Player> ().canMove) {
			Vector3 RequiredPosition = target.transform.position - offset;
			this.transform.position = Vector3.Lerp (this.transform.position, RequiredPosition, 1.5f);
		}
	}
}

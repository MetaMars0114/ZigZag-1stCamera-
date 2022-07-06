using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			Invoke ("FallDown", 0.6f);
		}
	}

	private void FallDown() {
		this.GetComponentInParent<Rigidbody>().isKinematic = false;
		Destroy (this.transform.parent.gameObject, 2f);
	}
}

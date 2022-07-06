using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Initialize variables.
	private float size;

	[SerializeField]
	GameObject platform;

	private Vector3 lastPosition;

	[SerializeField]
	GameObject gems;

	// Use this for initialization
	void Start () {
		size = platform.transform.localScale.x;
		lastPosition = platform.transform.position;

		// Create the first initial playforms.
		for (int x = 0; x < 15; x++) {
			SpawnZ ();
		}

		// Call the SpawnPlatform every 2 seconds.
		InvokeRepeating ("SpawnPlatform", 2f, 0.2f);
	}
	


	// Spawn a random platform.
	private void SpawnPlatform() {
		int random = Random.Range (0, 6);
		int gemsRandom = Random.Range (0, 7);

		if (random < 3) {
			SpawnX ();
		}

		if (random >= 3) {
			SpawnZ ();
		}

		if (gemsRandom < 2) {
			SpawnGem ();
		}
	}
	private void SpawnX() {
		GameObject _platform = Instantiate (platform) as GameObject;
		_platform.transform.position = lastPosition + new Vector3 (size, 0f,0f);
		lastPosition = _platform.transform.position;

		// Assigns a material named "Assets/Resources/Color1" to the object.
		Material newMat = Resources.Load("Color1", typeof(Material)) as Material;
		_platform.GetComponent<Renderer>().material = newMat;
	}

	private void SpawnZ() {
		GameObject _platform = Instantiate (platform) as GameObject;
		_platform.transform.position = lastPosition + new Vector3 (0f,0f,size);
		lastPosition = _platform.transform.position;

		// Assigns a material named "Assets/Resources/Color2" to the object.
		Material newMat = Resources.Load("Color2", typeof(Material)) as Material;
		_platform.GetComponent<Renderer>().material = newMat;
	}


	// Spawn a random gem.
	private void SpawnGem() {
		Instantiate (gems, lastPosition+ new Vector3(0f,0.7f,0f), gems.transform.rotation);

		// Assigns a material named "Assets/Resources/Color" (plus the random int) to the object.
		int rand = Random.Range(1,3);
		Material newMat = Resources.Load("Color" + (rand.ToString()), typeof(Material)) as Material;
		gems.GetComponent<Renderer>().material = newMat;
	}
}

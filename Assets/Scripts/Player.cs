using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	// Initialize variables.
	private Rigidbody rb;
	private bool isMovingRight = false;
	private bool hasPlayerStarted = false;

	[SerializeField]
	float speed = 4f;

	[HideInInspector]
	public bool canMove = true;

	[SerializeField]
	GameObject particle;

	[SerializeField]
	GameObject gems;

	[SerializeField]
	private Text scoreText;
	private int score = 0;


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && canMove == true) {

			// If the game hasen't started yet.
			if (hasPlayerStarted == false) {
				hasPlayerStarted = true;
				StartCoroutine (ShowGems (2.5f));
			}
				
			ChangeBoolean ();
			ChangeDirection ();
		}

		if (Physics.Raycast (this.transform.position, Vector3.down * 2) == false) {
			FallDown ();
		}
	}



	// Hide the gems for the first 2.5 seconds (avoiding bugs).
	IEnumerator ShowGems (float count) {
		yield return new WaitForSeconds (count);

		// Checks if player hasn't fallen off before showing grms.
		if (canMove == true) {
			gems.SetActive (true);
		}
	}
		

	// Control player direction.
	private void ChangeBoolean() {
		isMovingRight = !isMovingRight;
	}
	private void ChangeDirection() {
		if (isMovingRight == true) {
			rb.velocity = new Vector3 (speed, 0f, 0f);
		} 
		else {
			rb.velocity = new Vector3 (0f,0f,speed);
		}
	}


	// When the player falls off the platform.
	private void FallDown() {
		canMove = false;
		rb.velocity = new Vector3 (0f,-4f,0f);

		// Retutn to main menu.
		StartCoroutine (ReturnToMainMenu (2.8f));
	}
	// Return to main menu.
	IEnumerator ReturnToMainMenu (float count) {
		yield return new WaitForSeconds (count);
		Application.LoadLevel(0);
	}


	// When the player hits a gem.
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Gem") {

			// Remove the gem.
			Destroy (other.gameObject);
		
			// Create the particle effect.
			GameObject _particle = Instantiate (particle) as GameObject;
			_particle.transform.position = this.transform.position;
			Destroy (_particle, 1f);

			// Update the score.
			score++;
			scoreText.text = "Score: " + score.ToString();
		}
	}
}

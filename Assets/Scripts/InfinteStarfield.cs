using UnityEngine;
using System.Collections;

public class InfinteStarfield : MonoBehaviour {


	private Transform tx;
	private ParticleSystem.Particle[] points;

	public int starsMax = 100;
	public float starSize = 0.1f;
	public float starDistance = 5f;
	public float starClipDistance = 0f;
	private float starDistanceSqr;
	private float starClipDistanceSqr;


	// Use this for initialization
	void Start () {
		tx = transform;
		starDistanceSqr = starDistance * starDistance;
		starClipDistanceSqr = starClipDistance * starClipDistance;
	}


	private void CreateStars() {
		points = new ParticleSystem.Particle[starsMax];

		for (int i = 0; i < starsMax; i++) {
			points[i].position = Random.insideUnitSphere * starDistance + tx.position;
			points[i].color = new Color(1,1,1, 1);
			points[i].size = starSize;
		}
	}



	// Update is called once per frame
	void Update () {
		float distance = 5;
		//transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;

		if ( points == null ) CreateStars();

		for (int i = 0; i < starsMax; i++) {

			if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr) {
				points[i].position = Random.insideUnitSphere.normalized * starDistance + tx.position;
			}

			if ((points[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr) {
				float percent = (points[i].position - tx.position).sqrMagnitude / starClipDistanceSqr;
				points[i].color = new Color(1,1,1, percent);
				points[i].size = percent * starSize;
			}


		}



		// older versions of Unity
		// particleSystem.SetParticles ( points, points.Length );
		// Unity 5.4+ and probably some sooner versions
		GetComponent<ParticleSystem>().SetParticles(points, points.Length);  

	}
}
using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Vector3 target;
	float timer;
	int sec;
	
	// Use this for initialization
	void Start ()
	{
		target = ResetTarget ();
		sec = ResetSec ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (timer > sec) {
			target = ResetTarget ();
			sec = ResetSec ();
		}
		transform.Translate (target * 5 * Time.deltaTime);

		if(transform.position.x <= -12.0f || transform.position.x >= 12.0f ||
		    transform.position.y <= -3.0f || transform.position.y >= 3.0f){

			//target = ResetTarget();
			Vector2 initialPosition = new Vector2(0, 0);
			target = initialPosition;
			//transform.Translate(target *5* Time.deltaTime);
		}
		 
	}
	
	private Vector3 ResetTarget ()
	{
		Vector3 v3 = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range (-2.0f, 2.0f));
		return v3;
	}
	
	private int ResetSec ()
	{
		timer = 0;
		return Random.Range(1, 3);
	}
}

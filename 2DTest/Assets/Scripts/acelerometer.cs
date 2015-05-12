using UnityEngine;
using System.Collections;

public class acelerometer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(Input.acceleration.x * 0.3f, Input.acceleration.y * 0.3f,0);
		transform.eulerAngles = new Vector3 (pitch (), 0, roll());
	}

	private float pitch(){
		float Gx = Input.acceleration.x;
		float Gy = Input.acceleration.y;
		float Gz = Input.acceleration.z;
		return Mathf.Atan(Gy/(Mathf.Sqrt(Mathf.Pow(Gx,2) + Mathf.Pow(Gz,2))));
	}

	private float roll(){
		float Gx = Input.acceleration.x;
		float Gz = Input.acceleration.z;
		return Mathf.Atan(-Gx/Gz);
	}
}

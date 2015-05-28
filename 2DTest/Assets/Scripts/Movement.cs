using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	Vector3 target;
	float timer = 0;
	public float speed = 5.5f;
	Vector3 initPos;
	
	void Start (){
		
		initPos = new Vector3 (3.5f, 2.5f, 0);
	}
	
	void Update (){
		timer += Time.deltaTime;
		float step = speed * Time.deltaTime;
		Vector3 v= ResetTarget (initPos);
		initPos = v;
		transform.position = Vector3.MoveTowards (transform.position, v, step);

		resetPosition (transform.position.x, transform.position.y);
	}
	
	private Vector3 ResetTarget (Vector3 vec){
		float x = (53.5f*Mathf.Cos(45) * timer) + vec.x;
		float y = (-0.5f *9.8f *Mathf.Pow(timer, 2)) + (12.5f * Mathf.Sin(45) * timer) + vec.y;
		Vector3 v3 = new Vector3(x , y, 0);
		
		return v3;
	}
	
	private int ResetSec (){
		timer = 0;
		return Random.Range(1, 3);
	}
	
	private void resetPosition(float xPosition, float yPosition){
		if(xPosition <= 0.0f || xPosition >= 24.0f &&
		   yPosition <= -3.5f || yPosition >= 3.5f){
			
			//Vector3 initialPosition = new Vector2(1.5f, 1.5f);
			//target = initialPosition;
			Destroy(this.gameObject);
			GameObject angryBird = new GameObject();

			//return true;
		}
		//return false;
	}
}

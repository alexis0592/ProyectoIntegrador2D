using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {


	public void changeScene(string scene){
		Application.LoadLevel(scene);
	}
}

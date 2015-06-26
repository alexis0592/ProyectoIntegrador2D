using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	string typeName;
	private const string gameName = "DuckHunter";
	private const int numMaxGamers = 10;
	private const int numPort = 25000;
	private bool serverStarted = false;

	public void changeScene(string scene){
		Debug.Log("chanse scene");
		StartServer ();
		if (serverStarted) {
			Application.LoadLevel (scene);
		}
	}

	/// <summary>
	/// Starts the server. 
	/// </summary>
	private void StartServer()
	{
		Debug.Log("Start Server");
		try{
			Network.InitializeServer(numMaxGamers, numPort, !Network.HavePublicAddress());
			MasterServer.RegisterHost(typeName, gameName);

		}catch(UnityException ex){
			throw ex;
		}
	}

	/// <summary>
	/// Raises the server initialized event.
	/// </summary>
	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
		serverStarted = true;
	}

	void OnFailedToConnectToMasterServer(NetworkConnectionError info){
		Debug.Log ("Problemas en la conexion: " + info);
		serverStarted = false;
	}

	[RPC]
	void ReceiveInfoFromClient(string info){
		Debug.Log ("Informacion recibida: " + info);
	}

	[RPC]
	void SendInfoToServer(){}

	void Start(){
		typeName = "abcd1234";
	}

	void OnGUI(){
		if (Network.peerType == NetworkPeerType.Server) {
			GUIStyle style = new GUIStyle();
			style.normal.textColor = Color.black;
			GUI.Label(new Rect(50,50,100,25), "Numero Sesion: " + typeName, style);
			GUI.Label(new Rect(100,100,100,25), "Conexiones: " + Network.connections.Length, style);

		}
	}
}

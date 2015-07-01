﻿using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {


	private const string typeName = "abcd1234";
	private const string gameName = "DuckHunter";

	private bool isRefreshingHostList = false;
	private HostData[] hostList;

	private NetworkView nView;
	public GameObject gobjMira;
	void Start(){

	}

	public void changeScene(string scene){
		//JoinServer (hostList[0]);
		Debug.Log("Entr a change scene");
		RefreshHostList ();
		if (hostList != null) {
			JoinServer(hostList[0]);
			//SendInfoToServer();
			//Application.LoadLevel (scene);
		}
	}

	private void RefreshHostList(){
		Debug.Log("Entr a change RefreshHostList");
		if (!isRefreshingHostList){
			isRefreshingHostList = true;
			MasterServer.RequestHostList(typeName);	
		}
	}

	void OnMasterServerEvent(MasterServerEvent msEvent){
		Debug.Log("Entr a change OnMasterServerEvent");
		if (msEvent == MasterServerEvent.HostListReceived) {
			hostList = MasterServer.PollHostList ();
		}
	}

	private void JoinServer(HostData hostData){
		Debug.Log("Entr a change JoinServer");
		Network.Connect(hostData);
	}
	
	void OnConnectedToServer(){
		SpawnPlayer ();
		//Network.Instantiate (gobjMira, new Vector3 (0f, 0f, 0f), Quaternion.identity, 0);
		Debug.Log("Entr a change OnConnectedToServer");
		Debug.Log("Server Joined");
	}

	private void SpawnPlayer(){
	
		Network.Instantiate (gobjMira, new Vector3 (0f, 5f, 0f), Quaternion.identity, 0);
	}

	[RPC] 
	void SendInfoToServer(){
		string info = "Hola servidor";
		GetComponent<NetworkView>().RPC("ReceiveInfoFromClient", RPCMode.Server, info);
	}

	[RPC]
	void ReceiveInfoFromServer(string info){
		Debug.Log ("Informacion del servidor: " + info);
		Network.isMessageQueueRunning = false;
	}

	[RPC]
	void ReceiveInfoFromClient(string info){}
		
	[RPC]
	void SendInfoToClient(){}

}

using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "1";
    public void Start()
    {
        // setting 설정하기
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("Connecting to Server...");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("We Are Connected to " + PhotonNetwork.CloudRegion + " server! ");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log("Disconnected to Server");
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Connect() // 룸 접속
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Joining Random Room");
            PhotonNetwork.JoinRandomRoom();
        }

        else
        {
            Debug.Log("Network Disconnected. Could not join Room -  Try Reconnecting");
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    //빈 방 없음
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);

        Debug.Log("There is no empty room. Creating new Room");

        PhotonNetwork.CreateRoom(roomName: null, new RoomOptions { MaxPlayers = 20 });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Connected to Room");
        PhotonNetwork.LoadLevel("MarketPlace"); //씬 바꾸기를 동기화.
    }
}

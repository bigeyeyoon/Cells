using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviourPunCallbacks
{
    private static AppManager Instance;

    public GameObject playerPrefab;
    Transform[] spawnPositions;
     
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SpawnPlayer();

        if(PhotonNetwork.IsMasterClient)
        {
            //SpawnStands();
        }
    
    }

    private void SpawnPlayer()
    {
        int localPlayerIndex = PhotonNetwork.LocalPlayer.ActorNumber - 1; //내 플레이어는 0번, 다른 플레이어들은 1번부터
        var spawnPosition = spawnPositions[localPlayerIndex % PhotonNetwork.PlayerList.Length];

        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition.position, spawnPosition.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        //
    }

    public void AddScore( int playerNumber, int score)
    {
        if (!PhotonNetwork.IsMasterClient) return; //점수 변경은 호스트에게만
        //photonView.RPC(methodName: "RPCUpdateScoreText", RpcTarget.All, parameters: playerScores[0].ToString, playerScores[1].ToString);
    }

    [PunRPC]

    private void RPCUpdateScoreText(string player1ScoreText, string player2ScoreText)
    {
        //
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

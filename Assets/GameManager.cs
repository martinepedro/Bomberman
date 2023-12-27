using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;
    public GameObject playerPrefab;

    void Start()
    {
        System.Random rnd = new System.Random();
        PhotonNetwork.ConnectUsingSettings();
        var photonView = GetComponent<PhotonView>();
        PhotonNetwork.NickName = rnd.Next(1000, 9999).ToString();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conected to Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to Lobby");
        PhotonNetwork.JoinOrCreateRoom("Main", new RoomOptions { IsVisible = true, IsOpen = true, BroadcastPropsChangeToAll = true }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Connected to a room");
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint1.transform.position, Quaternion.identity);

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            Debug.Log("player >" + player.NickName + "< is on the lobby");
        }
    }
}

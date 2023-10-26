using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public string RoomName = "Default";
    public PlutoAPIs PlutoAPIs;
    public PlutoConnectionStatusChecker PlutoStatusChecker;

    public void OnAwake()
    {
        // PhotonNetwork.Disconnect();
        // PhotonNetwork.AddCallbackTarget(this);

        // // Start in single player mode so RPCs and other photon calls work
        // PhotonNetwork.OfflineMode = true;
    }

    public void Connect()
    {
        // Debug.Log("RoomManager connecting");

        // PhotonNetwork.LeaveRoom();
        // PhotonNetwork.OfflineMode = false;

        // PhotonNetwork.ConnectUsingSettings();
    }

    public void OnConnected() { }

    public void OnConnectedToMaster()
    {
        //Debug.Log("OnConnectedToMaster called");

        if (PlutoStatusChecker.IsLoggedIn)
            PlutoAPIs.Client.RoomsRoomIdJoin(RoomName);

        // PhotonNetwork.JoinOrCreateRoom(RoomName, new RoomOptions(), TypedLobby.Default);
    }

    // public void OnDisconnected(DisconnectCause cause) { }

    // public void OnRegionListReceived(RegionHandler regionHandler) { }

    public void OnCustomAuthenticationResponse(Dictionary<string, object> data) { }

    public void OnCustomAuthenticationFailed(string debugMessage) { }
}

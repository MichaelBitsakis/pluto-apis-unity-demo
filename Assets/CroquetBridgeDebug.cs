using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CroquetBridgeDebug : MonoBehaviour
{
    public CroquetBridge bridge;
    public TMP_Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bridge == null) return;

        debugText.text = "";
        debugText.text += bridge.croquetSessionState + "\n";
        debugText.text += bridge.sessionName + "\n";
        debugText.text += bridge.croquetViewId + "\n";
        debugText.text += bridge.croquetViewCount + "\n";
        debugText.text += bridge.croquetActiveScene + "\n";
        debugText.text += bridge.croquetActiveSceneState + "\n";
        debugText.text += bridge.unitySceneState + "\n";
    }
}

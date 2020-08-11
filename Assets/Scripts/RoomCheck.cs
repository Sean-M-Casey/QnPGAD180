using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCheck : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    string inRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inRoom = GameObject.Find("Lucille").GetComponent<DoorScripts>().inRoom;
        //1 is to select it, then name
        camera.cullingMask = (1 << LayerMask.NameToLayer(inRoom)) | (1 << LayerMask.NameToLayer("Default")) | (1 << LayerMask.NameToLayer("UI"));
    }
}

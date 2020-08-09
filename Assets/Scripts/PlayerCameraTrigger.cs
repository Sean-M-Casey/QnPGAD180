using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraTrigger : MonoBehaviour
{
    public GameObject[] Cameras;
    public GameObject[] camRails;
    public GameObject[] rooms;
    public GameObject[] triggers;
    public GameObject playerCam;
    public GameObject player;
    int roomNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (roomNum == i)
            {
                player.GetComponent<PlayerControls>().mainCamPosZ = camRails[i].transform.position.z;
            }
            if (roomNum != i)
            {
                rooms[i].SetActive(false);
            }
            if (roomNum == i)
            {
                rooms[i].SetActive(true);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == triggers[1].name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (roomNum == 0)
                {
                    gameObject.transform.position = Cameras[1].transform.position;
                    roomNum = 1;
                    playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
                    player.GetComponent<PlayerControls>().camMoveYes = true;
                }
                else if (roomNum == 1)
                {
                    gameObject.transform.position = Cameras[0].transform.position;
                    roomNum = 0;
                    playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
                    player.GetComponent<PlayerControls>().camMoveYes = true;
                }
            }
        }
        else if (other.name == triggers[0].name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (roomNum == 0)
                {
                    gameObject.transform.position = Cameras[5].transform.position;
                    roomNum = 2;
                    playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
                    player.GetComponent<PlayerControls>().camMoveYes = true;
                }
                else if (roomNum == 2)
                {
                    gameObject.transform.position = Cameras[4].transform.position;
                    roomNum = 0;
                    playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
                    player.GetComponent<PlayerControls>().camMoveYes = true;
                }
            }
        }
        else if (other.name == triggers[2].name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (roomNum == 0)
                {
                    gameObject.transform.position = Cameras[3].transform.position;
                    roomNum = 3;
                    playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
                    player.GetComponent<PlayerControls>().camMoveYes = true;
                }
                else if (roomNum == 3)
                {
                    gameObject.transform.position = Cameras[2].transform.position;
                    roomNum = 0;
                    playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
                    player.GetComponent<PlayerControls>().camMoveYes = true;
                }
            }
        }
        else if (other.name == triggers[3].name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (roomNum == 1)
                {
                    gameObject.transform.position = Cameras[7].transform.position;
                    roomNum = 4;
                    playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
                    player.GetComponent<PlayerControls>().camMoveYes = true;
                }
                else if (roomNum == 4)
                {
                    gameObject.transform.position = Cameras[8].transform.position;
                    roomNum = 1;
                    playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
                    player.GetComponent<PlayerControls>().camMoveYes = true;
                }
            }
        }
        else if (other.name == triggers[4].name)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (roomNum == 3)
                {
                    gameObject.transform.position = Cameras[6].transform.position;
                    roomNum = 4;
                    playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
                    player.GetComponent<PlayerControls>().camMoveYes = true;
                }
                else if (roomNum == 4)
                {
                    gameObject.transform.position = Cameras[9].transform.position;
                    roomNum = 3;
                    playerCam.transform.position = new Vector3(gameObject.transform.position.x, 3.91f, -13.38f);
                    player.GetComponent<PlayerControls>().camMoveYes = true;
                }
            }
        }
    }
}

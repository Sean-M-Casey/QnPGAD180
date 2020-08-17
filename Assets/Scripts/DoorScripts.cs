using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class DoorScripts : MonoBehaviour
{
    public GameObject foyer_kitchen;
    public GameObject kitchen_foyer;
    public GameObject kitchen_dining;
    public GameObject dining_kitchen;
    public GameObject dining_foyer;
    public GameObject foyer_dining;
    public GameObject foyer_laundry;
    public GameObject laundry_foyer;
    public GameObject foyer_master;
    public GameObject master_foyer;
    public GameObject foyer_living;
    public GameObject living_foyer;
    public GameObject cam_pos_foyer;
    public GameObject cam_pos_dining;
    public GameObject cam_pos_kitchen;
    public GameObject cam_pos_living;
    public GameObject cam_pos_master;
    public GameObject cam_pos_laundry;
    public GameObject main_camera;
    public GameObject player;
    public GameObject e_Key;
    public GameObject tutPrompt;
    public TextMesh tutText;
    public string inRoom;
    public UnityEvent startCutscene2;
    bool eKeyRun;
    bool tutprompting;
    bool eDown;
    int reEnterFoyer = 0;
    bool kitchenOnce;
    // Start is called before the first frame update
    void Start()
    {
        e_Key.SetActive(false);
        inRoom = "Foyer";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            eDown = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            eDown = false;
        }
        if (inRoom == "Kitchen" && kitchenOnce == false)
        {
            reEnterFoyer = 1;
            kitchenOnce = true;
        }
        if (inRoom == "Foyer" && reEnterFoyer == 1)
        {
            reEnterFoyer = 2;
        }
        if (reEnterFoyer == 2)
        {
            startCutscene2.Invoke();
            reEnterFoyer++;
        }
    }
    IEnumerator TutPrompt()
    {
        tutPrompt.SetActive(true);
        tutText.text = "You can also interact with certain objects";
        yield return new WaitForSeconds(2f);
        tutPrompt.SetActive(false);
        tutText.text = "";
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == foyer_kitchen.name && !eKeyRun)
        {
            e_Key.SetActive(true);
            eKeyRun = true;
            tutPrompt.SetActive(true);
            tutText.text = "Press ‘E’ to interact";
        }
        if (eDown)
        {
            if (other.name == foyer_kitchen.name)
            {
                player.transform.position = kitchen_foyer.transform.position;
                inRoom = "Kitchen";
                main_camera.transform.position = cam_pos_kitchen.transform.position;
                e_Key.SetActive(false);
                eDown = false;
                tutPrompt.SetActive(false);
                tutText.text = "";
                if (!tutprompting)
                {
                    StartCoroutine(TutPrompt());
                    tutprompting = true;
                }
            }
            if (other.name == kitchen_foyer.name)
            {
                player.transform.position = foyer_kitchen.transform.position;
                inRoom = "Foyer";
                main_camera.transform.position = cam_pos_foyer.transform.position;
                eDown = false;
            }
            if (other.name == kitchen_dining.name)
            {
                player.transform.position = dining_kitchen.transform.position;
                inRoom = "DiningRoom";
                main_camera.transform.position = cam_pos_dining.transform.position;
                eDown = false;
            }
            if (other.name == dining_kitchen.name)
            {
                player.transform.position = kitchen_dining.transform.position;
                inRoom = "Kitchen";
                main_camera.transform.position = cam_pos_kitchen.transform.position;
                eDown = false;
            }
            if (other.name == dining_foyer.name)
            {
                player.transform.position = foyer_dining.transform.position;
                inRoom = "Foyer";
                main_camera.transform.position = cam_pos_foyer.transform.position;
                eDown = false;
            }
            if (other.name == foyer_dining.name)
            {
                player.transform.position = dining_foyer.transform.position;
                inRoom = "DiningRoom";
                main_camera.transform.position = cam_pos_dining.transform.position;
                eDown = false;
            }
            if (other.name == foyer_living.name)
            {
                player.transform.position = living_foyer.transform.position;
                inRoom = "Living";
                main_camera.transform.position = cam_pos_living.transform.position;
                eDown = false;
            }
            if (other.name == living_foyer.name)
            {
                player.transform.position = foyer_living.transform.position;
                inRoom = "Foyer";
                main_camera.transform.position = cam_pos_foyer.transform.position;
                eDown = false;
            }
            if (other.name == foyer_master.name)
            {
                player.transform.position = master_foyer.transform.position;
                inRoom = "MasterBedroom";
                main_camera.transform.position = cam_pos_master.transform.position;
                eDown = false;
            }
            if (other.name == master_foyer.name)
            {
                player.transform.position = foyer_master.transform.position;
                inRoom = "Foyer";
                main_camera.transform.position = cam_pos_foyer.transform.position;
                eDown = false;
            }
            if (other.name == foyer_laundry.name)
            {
                player.transform.position = laundry_foyer.transform.position;
                inRoom = "Laundry";
                main_camera.transform.position = cam_pos_laundry.transform.position;
                eDown = false;
            }
            if (other.name == laundry_foyer.name)
            {
                player.transform.position = foyer_laundry.transform.position;
                inRoom = "Foyer";
                main_camera.transform.position = cam_pos_foyer.transform.position;
                eDown = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidBody;
    public Animator LucilleAnim;
    public GameObject mainCam;
    public bool mouseLock;
    public float mainCamPosZ;
    public float mainCamDefaultPosZ = 13.38f;
    public bool camMoveYes = true;
    public bool wallFlashTrigger;
    public bool canMove;
    bool collisionYes;

    //Sound effect for floating
    public AudioSource floatingSound;

    //particle effects for walking
    public ParticleSystem smoke1;
    public ParticleSystem smoke2;
    public ParticleSystem smoke3;



    void Start()
    {
        mouseLock = false;
        rigidBody = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Getting Direction for Movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (canMove)
        {
            //Makes Character Move in regards to movement variable
            rigidBody.AddForce(movement * speed);
            if (!collisionYes)
            {
                camMoveYes = true;
            }
        }
        else if (!canMove)
        {
            camMoveYes = false;
        }
        
        //Removes velocity when movement keys are released so that player doesnt continue moving
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
        {
            StartCoroutine(stopMove());
        }

        // Movement Animator Triggers
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                LucilleAnim.SetBool("Down_Walk_B", true);
                LucilleAnim.SetBool("Left_Walk_B", false);
                LucilleAnim.SetBool("Right_Walk_B", false);
                floatingSound.Play();
                SmokeUp();

            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                LucilleAnim.SetBool("Up_Walk_B", true);
                LucilleAnim.SetBool("Left_Walk_B", false);
                LucilleAnim.SetBool("Right_Walk_B", false);
                SmokeUp();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                LucilleAnim.SetBool("Left_Walk_B", true);
                SmokeUp();

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                LucilleAnim.SetBool("Right_Walk_B", true);
                SmokeUp();

            }
            if (moveHorizontal == 0 && moveVertical == 0)
            {
                LucilleAnim.SetTrigger("To_Idle");
                LucilleAnim.SetBool("Left_Walk_B", false);
                LucilleAnim.SetBool("Right_Walk_B", false);
                LucilleAnim.SetBool("Down_Walk_B", false);
                LucilleAnim.SetBool("Up_Walk_B", false);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                LucilleAnim.SetBool("Left_Walk_B", false);
                LucilleAnim.SetBool("Right_Walk_B", false);
                LucilleAnim.SetBool("Down_Walk_B", false);
                LucilleAnim.SetBool("Up_Walk_B", false);
                SmokeNo();
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                LucilleAnim.SetBool("Left_Walk_B", false);
                LucilleAnim.SetBool("Right_Walk_B", false);
                LucilleAnim.SetBool("Down_Walk_B", false);
                LucilleAnim.SetBool("Up_Walk_B", false);
                SmokeNo();            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                LucilleAnim.SetBool("Left_Walk_B", false);
                LucilleAnim.SetBool("Right_Walk_B", false);
                LucilleAnim.SetBool("Down_Walk_B", false);
                LucilleAnim.SetBool("Up_Walk_B", false);
                SmokeNo();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                LucilleAnim.SetBool("Left_Walk_B", false);
                LucilleAnim.SetBool("Right_Walk_B", false);
                LucilleAnim.SetBool("Down_Walk_B", false);
                LucilleAnim.SetBool("Up_Walk_B", false);
                SmokeNo();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Wall__Prompt_Trigger")
        {
            wallFlashTrigger = true;
        }
    }

    //event trigger that changes state of mouselock
    public void UpdateMouseLock()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            StartCoroutine(Unlock());
        }
        else
        {
            StartCoroutine(Lock());
        }
    }
    private IEnumerator Unlock()
    {
        Cursor.lockState = CursorLockMode.Confined;
        yield return new WaitForSeconds(0.01f);
        Cursor.lockState = CursorLockMode.None;
    }
    private IEnumerator Lock()
    {
        Cursor.lockState = CursorLockMode.Confined;
        yield return new WaitForSeconds(0.01f);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private IEnumerator stopMove()
    {
        yield return new WaitForSeconds(0.02f);
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        mainCam.GetComponent<Rigidbody>().velocity = Vector3.zero;
        mainCam.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    
    // Smokeup plays smoke behind Lucille, it also plays floating sounds. 
    void SmokeUp()
    {
        smoke1.Play();
        smoke2.Play();
        smoke3.Play();
        floatingSound.Play();
    }
    // Smokeup stops smoke behind Lucille, it also plays floating sounds. 
    void SmokeNo()
    {
        smoke1.Stop();
        smoke2.Stop();
        smoke3.Stop();
        floatingSound.Stop();
    }
}
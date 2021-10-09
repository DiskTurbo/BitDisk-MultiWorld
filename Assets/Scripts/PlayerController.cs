using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using JSAM;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera tpCamera;

    [SerializeField] float mouseSensitivity, walkSpeed, rollForce, smoothTime;

    [SerializeField] Animator anim;

    [SerializeField] AudioMixerGroup Master;

    [SerializeField] GameObject model;

    public Vector3 smoothMoveVelocity;
    public float turnSmoothVelocity;
    Vector3 moveAmount;

    Quaternion toRotation;

    [SerializeField] Rigidbody rb;

    void Awake()
    {
        Master = GetComponent<AudioMixerGroup>();
        Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 20;
    }

    void Update()
    {
        Move();
    }
    
    void Look()
    {
        this.transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * 6);
    }

    void Move()
    {
        if(anim.GetBool("isRunning") == true && JSAM.AudioManager.IsSoundPlaying(Sounds.LinkRun) == false)
        {
            JSAM.AudioManager.PlaySoundLoop(Sounds.LinkRun);
        }
        else if (anim.GetBool("isRunning") == false || anim.GetBool("isRolling") == true)
        {
            JSAM.AudioManager.StopSoundLoop(Sounds.LinkRun);
        }

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * walkSpeed, ref smoothMoveVelocity, smoothTime);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    void Roll()
    {
        JSAM.AudioManager.PlaySound(Sounds.RollSFX);
        JSAM.AudioManager.PlaySound(Sounds.LinkRoll1);
        Invoke("StopRolling", 0.65f);
    }

    void StopRolling()
    {
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}

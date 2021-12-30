using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float Speed = 3.0f;
    Animator animator;

    [SerializeField]
    GameObject damage;

    [SerializeField]
    Transform CameraTransform;

    bool cursorInScreen = true;

    Vector3 dir = Vector3.zero;
    Quaternion qDir;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            CursorLock();


        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Left Attack");
            transform.rotation = Quaternion.Euler(0, CameraTransform.rotation.eulerAngles.y, 0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("Right Attack", true);
            transform.rotation = Quaternion.Euler(0, CameraTransform.rotation.eulerAngles.y, 0);
        }

        if (animator.GetBool("Movable") == false) return;

        animator.SetFloat("Speed", 0.0f);
        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (dir.sqrMagnitude > 0.1)
        {
            Turn(dir);
            RunForward();
        }
    }

    void RunForward()
    {
        transform.Translate(Speed * Vector3.forward * Time.deltaTime);
        animator.SetFloat("Speed", 3.0f);
    }

    void Turn(Vector3 dir)
    {
        transform.rotation = 
            Quaternion.LookRotation(dir, Vector3.up) *
            Quaternion.Euler(0, CameraTransform.rotation.eulerAngles.y, 0);
    }


    public void OnDamage()
    {
        damage?.SetActive(true);
    }

    public void OffDamage()
    {
        damage?.SetActive(false);
    }

    public void CursorLock()
    {
        cursorInScreen = !cursorInScreen;
        Cursor.lockState = cursorInScreen ? CursorLockMode.Locked : CursorLockMode.None;
    }
}

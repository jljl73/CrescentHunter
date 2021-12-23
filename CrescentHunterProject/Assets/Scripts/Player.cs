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

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CursorLock();

            animator.SetFloat("Speed", 0.0f);
        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("Left Attack");
        if (Input.GetMouseButtonDown(1))
            animator.SetBool("Right Attack", true);




        if (animator.GetBool("Movable") == false) return;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Speed * Vector3.forward * Time.deltaTime);
            animator.SetFloat("Speed", 3.0f);

            transform.rotation = Quaternion.Euler(0, CameraTransform.rotation.eulerAngles.y, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Speed * Vector3.left * Time.deltaTime);
            animator.SetFloat("Speed", 3.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Speed * Vector3.back * Time.deltaTime);
            animator.SetFloat("Speed", 3.0f);
            transform.rotation = Quaternion.Euler(0, CameraTransform.rotation.eulerAngles.y, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Speed * Vector3.right * Time.deltaTime);
            animator.SetFloat("Speed", 3.0f);
        }
                
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

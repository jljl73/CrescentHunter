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

    [SerializeField]
    GameObject SelectedObject;

    bool cursorInScreen = true;

    Vector3 dir = Vector3.zero;
    Quaternion qDir;

    List<GameObject> NearObjects = new List<GameObject>();

    public static Player Instance;

    void Start()
    {
        animator = GetComponent<Animator>();
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            CursorLock();

        if (Input.GetKeyDown(KeyCode.G))
            Interaction();


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

        if (animator.GetBool("Movable") == false)
            return;

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

    void Interaction()
    {
        SelectedObject = NearestObject();
        SelectedObject?.GetComponent<IInteraction>().OnInteraction();
    }
    
    GameObject NearestObject()
    {
        if (NearObjects.Count == 0)
            return null;

        int i = NearObjects.Count - 1;
        GameObject Nearest = NearObjects[i];
        float MinDistance = (Nearest.transform.position - transform.position).sqrMagnitude;

        for (; i >= 0; --i)
        {
            float dist = (NearObjects[i].transform.position - transform.position).sqrMagnitude;
            if(dist < MinDistance)
            {
                dist = MinDistance;
                Nearest = NearObjects[i];
            }
        }

        return Nearest;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interaction"))
            NearObjects.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interaction"))
            NearObjects.Remove(other.gameObject);
    }
}

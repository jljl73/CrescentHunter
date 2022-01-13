using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float Speed = 3.0f;
    [SerializeField]
    float NumStaminaHeal = 3.0f;

    [SerializeField]
    GameObject damage;

    [SerializeField]
    Transform CameraTransform;

    [SerializeField]
    GameObject SelectedObject;


    bool cursorInScreen = true;
    Vector3 dir = Vector3.zero;

    List<GameObject> NearObjects = new List<GameObject>();

    Animator animator;
    PlayerStatus status;

    public Inventory inventory = new Inventory();

    void Awake()
    {
        GameManager.Instance.player = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        status = GetComponent<PlayerStatus>();
    }



    void Update()
    {
        if (animator.GetBool("Movable"))
            status.AddStamina(Time.deltaTime * NumStaminaHeal);

        if (Input.GetKeyDown(KeyCode.Z))
            CursorLock();

        if (Input.GetKeyDown(KeyCode.G))
        {
            Interaction();
        }
        if (Input.GetMouseButtonDown(0))
        {
            LightAttack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            HeavyAttack();
        }
        if (Input.GetMouseButtonUp(1))
        {
            HeavyAttackEnd();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Roll();

        if (Input.GetKeyDown(KeyCode.Q))
            inventory.ChangeSlot(false);
        if (Input.GetKeyDown(KeyCode.E))
            inventory.ChangeSlot(true);
        if (Input.GetKeyDown(KeyCode.F))
            inventory.UseCurrentSlot(status);
    }
    
    void FixedUpdate()
    {
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

    void LightAttack()
    {
        if (status.Stamina < 5)
            return;

        animator.SetTrigger("Left Attack");
        transform.rotation = Quaternion.Euler(0, CameraTransform.rotation.eulerAngles.y, 0);
    }

    void HeavyAttack()
    {
        if (status.Stamina < 10)
            return;

        animator.SetBool("Right Attack", true);
        transform.rotation = Quaternion.Euler(0, CameraTransform.rotation.eulerAngles.y, 0);
    }

    void HeavyAttackEnd()
    {
        animator.SetBool("Right Attack End", true);
    }

    void Roll()
    {
        if (status.Stamina < 10)
            return;

        animator.SetTrigger("Roll");
        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Turn(dir);
    }

    public void OnDamage()
    {
        damage?.SetActive(true);
    }

    public void OffDamage()
    {
        damage?.SetActive(false);
        status.AddStamina(-5);
    }

    public void CursorLock()
    {
        cursorInScreen = !cursorInScreen;
        Cursor.lockState = cursorInScreen ? CursorLockMode.Locked : CursorLockMode.None;
    }

    void Interaction()
    {
        SelectedObject = NearestObject();
        if (SelectedObject == null)
            return;

        SelectedObject.GetComponent<IInteraction>().OnInteraction();
        if (SelectedObject.GetComponent<IInteraction>() is ItemObject)
        {
            ClearText(SelectedObject);
            Destroy(SelectedObject);
        }
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
        {
            NearObjects.Add(other.gameObject);
            GameManager.Instance.HUDContext.ItemName = NearestObject()?.GetComponent<IInteraction>().IName;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interaction"))
        {
            ClearText(other.gameObject);
        }
    }

    void ClearText(GameObject other)
    {
        NearObjects.Remove(other);
        if (NearestObject() == null)
            GameManager.Instance.HUDContext.ItemName = "";
        else
            GameManager.Instance.HUDContext.ItemName = NearestObject().GetComponent<IInteraction>().IName;
    }
}

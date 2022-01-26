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

    [SerializeField]
    GameObject SwordSlotHand;
    [SerializeField]
    GameObject SwordSlotBack;

    Vector3 dir = Vector3.zero;

    List<GameObject> NearObjects = new List<GameObject>();

    Animator animator;
    PlayerStatus status;
    Equipment equipment;

    public Inventory inventory;

    void Awake()
    {
        GameManager.Instance.player = this;
        inventory = Inventory.Instance;
        animator = GetComponent<Animator>();
        status = GetComponent<PlayerStatus>();
        equipment = GetComponentInChildren<Equipment>();
    }


    void Update()
    {
        if (GameManager.Instance.GameMode != GameManager.Mode.Play) return;


        if (animator.GetBool("Movable"))
            status.AddStamina(Time.deltaTime * NumStaminaHeal);

        

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
            Drink();
    }
    
    void FixedUpdate()
    {

        // 초기화
        if (animator.GetBool("Movable") == false)
            return;
        animator.SetFloat("Speed", 0.0f);
        
        //
        if (GameManager.Instance.GameMode != GameManager.Mode.Play)
            return;
        
        // 입력
        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (dir.sqrMagnitude > 0.1)
        {
            Turn(dir);
            RunForward(dir.sqrMagnitude);
        }
    }

    void RunForward(float speed)
    {
        if(animator.GetBool("Unarmed"))
            transform.Translate(Speed * Vector3.forward * Time.deltaTime);
        //else
        //    transform.Translate(Speed * Vector3.forward * Time.deltaTime * 0.2f);
        animator.SetFloat("Speed", speed);
    }

    void Turn(Vector3 dir)
    {
        transform.rotation =
            Quaternion.LookRotation(dir, Vector3.up) *
            Quaternion.Euler(0, CameraTransform.rotation.eulerAngles.y, 0);
    }

    void LightAttack()
    {
        if (!CheckUnarmed(false))
            return;

        if (status.Stamina < 5 || animator.GetBool("Dead"))
            return;
        
        animator.SetTrigger("Left Attack");
        transform.rotation = Quaternion.Euler(0, CameraTransform.rotation.eulerAngles.y, 0);
    }

    void HeavyAttack()
    {
        if (!CheckUnarmed(false))
            return;

        if (status.Stamina < 10 || animator.GetBool("Dead"))
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

    void UseItem()
    {
        if(!inventory.IsEmpty)
            inventory.UseCurrentSlot(status);
    }

    void Drink()
    {
        if (CheckUnarmed(true))
            animator.SetTrigger("Drink");
    }

    bool CheckUnarmed(bool value)
    {
        if (animator.GetBool("Unarmed") == value)
            return true;

        animator.SetTrigger("WeaponSwitch");
        return false;
    }

    void Die()
    {
        GameManager.Instance.Restart();
    }


    public void Resurrection()
    {
        animator.SetTrigger("Getup");
        status.Initialize();
    }

    public void OnDamage(float value)
    {
        damage.GetComponent<DamageCollider>().Damage = value + equipment.GetCurrentWeapon().Damage;  
        damage?.SetActive(true);
    }

    public void OffDamage(int value)
    {
        damage?.SetActive(false);
    }

    public void UseStamina(int value)
    {
        status.AddStamina(value);
    }

    public void OnEquip(int index)
    {
        equipment.OnUnequip();
        equipment.OnEquip(index);
    }

    public void OnSwitch(int Unarmed)
    {
        if (Unarmed == 0)
        {
            equipment.transform.SetParent(SwordSlotBack.transform);
            animator.SetBool("Unarmed", true);
        }
        else
        {
            equipment.transform.SetParent(SwordSlotHand.transform);
            animator.SetBool("Unarmed", false);
        }

        equipment.transform.localPosition = Vector3.zero;
        equipment.transform.localRotation = Quaternion.identity;
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

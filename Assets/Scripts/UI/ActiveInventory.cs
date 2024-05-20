using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveInventory : MonoBehaviour
{
    private int activeSlotIndexNum = 0;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
    }

    private void OnEnable()
    {
        playerControls.Enable();
            
    }
     
    private void ToggleActiveSlot(int numValue)
    {
        ToggleActiveSlotHighLight(numValue - 1);
    }

    private void ToggleActiveSlotHighLight( int indexNum)
    {
        activeSlotIndexNum= indexNum;

        foreach( Transform inventorySlot in this.transform )
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);

        ChangeActiveWeapon();
    }

    private void ChangeActiveWeapon()
    {
        Debug.Log(transform.GetChild(activeSlotIndexNum).GetComponent<InventorySlot>().GetWeaponInfo().weaponPrefab);
    }
}

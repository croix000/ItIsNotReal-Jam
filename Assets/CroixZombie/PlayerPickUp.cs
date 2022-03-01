using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerPickUp : MonoBehaviour
{

    [SerializeField]
    private LayerMask pickupLayer;
    [SerializeField]
    private float pickUpRange;


    [SerializeField]
    private GameObject hint;

    public InputAction useAction;


    private void Awake()
    {

        useAction.performed += PickUpAction;
    }
    private void Update()
    {
        Ray pickupRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);


        if (Physics.Raycast(pickupRay, out RaycastHit hitInfo, pickUpRange, pickupLayer))
        {


            hint.SetActive(true);

        }
        else {

            hint.SetActive(false);
        }
    }

    void OnEnable()
    {
        useAction.Enable();
    }
    void OnDisable()
    {
        useAction.Disable(); 
    
    }
    public void PickUpAction(InputAction.CallbackContext context)
    {

        Ray pickupRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        
      

        Debug.Log("trying to pick up");
       
        if (Physics.Raycast(pickupRay, out RaycastHit hitInfo, pickUpRange, pickupLayer))
        {

            hitInfo.collider.gameObject.SetActive(false);

            GameManager.Instance.MedPickUp();

        }

    }



}

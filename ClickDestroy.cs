using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDestroy : MonoBehaviour
{
    InputSystem input;
    public bool isClicked;
    public GameObject shootObject;
    void Awake()
    {
        input = new InputSystem();
        input.Click.Touch.performed += OnTap;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Click.Touch.performed += OnTap;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Click.Touch.performed -= OnTap;
    }

    void OnTap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log(isClicked);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log(Input.mousePosition);
            
            //these are the values of the aim object
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //this line spawns an aim object
            Instantiate(shootObject, position, Quaternion.identity);

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject == gameObject)
                {
                    isClicked = true;
                    Debug.Log(isClicked);
                }
            }
        }
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
    }

    
}

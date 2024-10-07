using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;
    InputSystem input;

    public Transform spawnObject;
    public GameObject arrowObject;
    public float shootSpeed;

    void Awake()
    {
        input = new InputSystem();
        input.Click.Touch.performed += OnShoot;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Click.Touch.performed += OnShoot;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Click.Touch.performed -= OnShoot;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    void OnShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            GameObject arrow = Instantiate(arrowObject, spawnObject.position, spawnObject.transform.rotation);
            Rigidbody2D rb2d = arrow.GetComponent<Rigidbody2D>();
            rb2d.AddForce(spawnObject.rotation * Physics.gravity * shootSpeed, ForceMode2D.Force);
        }
    }
}

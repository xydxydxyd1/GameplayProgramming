using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Movement
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;

    // PickUp
    private int pickUpCount;
    public TextMeshProUGUI pickUpCountText;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        pickUpCount = 0;
        SetPickUpCountText();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetPickUpCountText()
    {
        pickUpCountText.text = $"Count: {pickUpCount}";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickUpCount++;
            SetPickUpCountText();
        }
    }
}

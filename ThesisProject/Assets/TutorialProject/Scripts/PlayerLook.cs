using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    // Start is called before the first frame update
    public int MouseSensitivity = 1;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Camera camera;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private float mouseX;
    private float mouseY;
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {

        xRotation -= mouseY * MouseSensitivity;
        yRotation += mouseX * MouseSensitivity;

        xRotation = Mathf.Clamp(xRotation, -89f, 89f);

        player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        camera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

    }

    private void OnLook(InputValue input)
    {
        if (input == null) return;
        mouseX = input.Get<Vector2>().x * Time.deltaTime;
        mouseY = input.Get<Vector2>().y * Time.deltaTime;
    }

   
}

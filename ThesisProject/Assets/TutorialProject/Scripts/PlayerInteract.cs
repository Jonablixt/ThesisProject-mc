using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    private CameraSwitch CameraSwitch;
    private Camera activeCamera;
    private Ray ray;
    public float InteractDistance;
    public int damage = 1;
    private RaycastHit hit;
    private Animator animator;
    void Start()
    {
        CameraSwitch = GetComponent<CameraSwitch>();
        animator = GetComponent<Animator>();
        CheckActiveCamera();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CheckActiveCamera()
    {
        activeCamera = CameraSwitch.CList[CameraSwitch.enabledIndex];
        ray = new Ray(activeCamera.transform.position, activeCamera.transform.forward);

    }

    private void OnInteract(InputValue input)
    {
        if (input == null) return;
        CheckActiveCamera();

       
        if (Physics.Raycast(ray, out hit, InteractDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    private void OnHit(InputValue input)
    {
        if (input == null) return;

        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
        {
            CheckActiveCamera();
            animator.SetTrigger("IsSwinging");
            if (Physics.Raycast(ray, out hit, InteractDistance))
            {
                IDamageble damageble = hit.collider.GetComponent<IDamageble>();

                if (damageble != null)
                {
                    damageble.TakeDamage(damage);
                }
            }
        }
       
    }
}
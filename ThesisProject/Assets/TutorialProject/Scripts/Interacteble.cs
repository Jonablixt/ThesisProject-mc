using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class Interacteble : MonoBehaviour, IInteractable
{
    DialogueManager dialogueManager;
    public SO_Dialouge too_Close_Dialouge;
    public List<SO_Dialouge> dialogueList;
    private GameObject player;
    private float tooCloseDistance = 1f;
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Interact()
    {
            
        bool playerTooClose = Vector3.Distance(player.transform.position, this.transform.position) < tooCloseDistance;

        if (dialogueManager.indialogue == false)
        {
            dialogueManager.indialogue = true;
            if (playerTooClose)
            {
                dialogueManager.InsertNewDialogue(too_Close_Dialouge.dialogueList);
            }
            else
            {
                dialogueManager.InsertNewDialogue(dialogueList[Random.Range(0,dialogueList.Count)].dialogueList);
            }
        }
    }
}
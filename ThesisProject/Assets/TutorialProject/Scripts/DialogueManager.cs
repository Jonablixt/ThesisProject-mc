using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public bool indialogue = false;
    private bool isTyping = false;

    private string completeText;
    public float typingSpeed = 0.05f;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    private GameObject player;
    private float inputDelay = 0.2f;

    Queue<SO_Dialouge.Info> DialogueQueue;
    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    IEnumerator TypeText()
    {
        isTyping = true;

        for (int i = 0; i < completeText.Length; i++)
        {
            if (isTyping == false)
            {
                dialogueText.text = completeText;
                yield break;
            }
            dialogueText.text += completeText[i];
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    public void LoadNextDialouge()
    {
        if (DialogueQueue.Count == 0)
        {
            indialogue = false;
            dialoguePanel.SetActive(false);
            player.GetComponent<PlayerInteract>().enabled = true;
            player.GetComponent<CameraSwitch>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<PlayerLook>().enabled = true;
            return;
        }
        SO_Dialouge.Info info = DialogueQueue.Dequeue();
        completeText = info.Dialogue;
        dialogueText.text = "";
        StartCoroutine(TypeText());
    }

    // Update is called once per frame
    void Update()
    {
        if(indialogue == true && inputDelay > 0)
        {
            inputDelay -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.E) && indialogue == true && inputDelay <= 0)
        {
            if (isTyping == true)
            {
                isTyping = false;
            }
            else
            {
                LoadNextDialouge();
                inputDelay = 0.2f;
            }
        }
    }
    public void InsertNewDialogue(List<SO_Dialouge.Info> dialogueList)
    {
        DialogueQueue = new Queue<SO_Dialouge.Info>(dialogueList);
        LoadNextDialouge();
        player.GetComponent<PlayerInteract>().enabled = false;
        dialoguePanel.SetActive(true);
        player.GetComponent<CameraSwitch>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerLook>().enabled = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    private GameObject playerObject;
    public GameObject BackGround;
    public GameObject PauseMenuObject;
    public GameObject PauseStartMenuObject;
    public GameObject MenuListObject;
    
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        ResetPauseUI();
        PauseGame();
    }

    public void OnPauseGame(InputValue value)
    {
        if (value == null) return;

        if(isPaused)
        {
            UnPauseGame();
        }
        else { PauseGame();}
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseStartMenuObject.SetActive(true);
        BackGround.SetActive(true);
    }
    public void UnPauseGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        playerObject.GetComponent<PlayerInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseStartMenuObject.SetActive(false);
        BackGround.SetActive(false);

        ResetPauseUI();
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ResetPauseUI()
    {
        for (int i = 0; i < PauseMenuObject.transform.childCount; i++)
        {
            MenuListObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
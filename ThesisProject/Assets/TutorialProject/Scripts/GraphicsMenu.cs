using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public Slider sensSlider;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void ChangeSensitivity()
    {
       // sliderValue = sensSlider.value;
        player.GetComponent<PlayerLook>().MouseSensitivity = (int)sensSlider.value;
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

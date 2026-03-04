using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundBank: MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundBank SB {get; private set;}

    public AudioClip stepsAudio;
    private void Awake()
    {
        // if there is an intance and it is not me delete myself

        if (SB != null && SB != this)
        {
            Destroy(this);
        }
        else
        {
            SB = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

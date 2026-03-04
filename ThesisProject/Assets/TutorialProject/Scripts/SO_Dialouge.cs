using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="MY_New_Dialogue", menuName = "MY_Dialogue")] 
public class SO_Dialouge : ScriptableObject
{
    public List<Info> dialogueList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class Info
    {
        [TextArea(4, 8)]
        public string Dialogue;
    }
}



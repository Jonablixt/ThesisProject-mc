using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MY_New_Weapon", menuName = "MY_Weapon")]

public class SO_Weapon : ScriptableObject
{
    // Start is called before the first frame update
    public string Name;
    public float AttackSpeed;
    public float AttackDamage;
    public Mesh WeaponMesh;
    public Vector3 Rotation;
    public bool FireEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

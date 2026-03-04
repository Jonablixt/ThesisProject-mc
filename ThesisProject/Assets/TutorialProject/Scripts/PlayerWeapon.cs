using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    private string Name;
    private float AttackSpeed;
    private float AttackDamage;
    private MeshCollider WeaponCollider;
    public SO_Weapon StartingWeapon;
    private MeshFilter WeaponMeshFilter;
    private ParticleSystem WeaponParticleSystem;
    void Start()
    {
        WeaponCollider = GetComponent<MeshCollider>();
        WeaponMeshFilter = GetComponent<MeshFilter>();
        WeaponParticleSystem = GetComponent<ParticleSystem>();
        LoadWeapon(StartingWeapon);
    }
    private void LoadWeapon(SO_Weapon weapon)
    {
        Name = weapon.Name;
        AttackSpeed = weapon.AttackSpeed;
        AttackDamage = weapon.AttackDamage;
        WeaponMeshFilter.mesh = weapon.WeaponMesh;
        WeaponCollider.sharedMesh = WeaponMeshFilter.sharedMesh;
        transform.localRotation = Quaternion.Euler(weapon.Rotation);
        WeaponParticleSystem.emissionRate = weapon.FireEffect ? 10 : 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponManager : MonoBehaviour
{
    public Weapon[] weapons;

    private int idWeapon = 0;

    private AudioSource audioSrc;

    private void Start()
    {
        this.audioSrc = GetComponent<AudioSource>();
        audioSrc.loop = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) fireShip();
    }

    private void fireShip()
    {
        for (int i = 0; i < weapons[idWeapon].CountCannons; i++)
        {
            GameObject.Instantiate(weapons[idWeapon].bullePref, weapons[idWeapon].cannons[i].position, weapons[idWeapon].cannons[i].rotation);

            audioSrc.Stop();
            audioSrc.clip = weapons[idWeapon].clip;
            audioSrc.Play();
        }
    }
}

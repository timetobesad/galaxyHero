using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public AudioClip clip;
    public GameObject bullePref;
    public Transform[] cannons;

    public int CountCannons
    {
        get { return this.cannons.Length; }
    }
}

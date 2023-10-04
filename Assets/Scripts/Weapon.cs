using UnityEngine;

[System.Serializable]
public class Weapon
{
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private GameObject bullePref;
    [SerializeField]
    private Transform[] cannons;
    [SerializeField]
    private Texture iconHud;
    [SerializeField]
    private int dammage;

    public AudioClip Clip
    {
        get { return this.clip; }
    }

    public GameObject BulletPref
    {
        get { return this.bullePref; }
    }

    public Transform[] Cannons
    {
        get { return this.cannons; }
    }

    public Texture IconHud
    {
        get { return this.iconHud; }
    }

    public int Dammage
    {
        get { return this.dammage; }
    }
}

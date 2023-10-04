using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponManager : MonoBehaviour
{
    public Weapon[] weapons;

    private int idWeapon = 0;

    private AudioSource audioSrc;

    public string hudHint;

    public Rect rHudHint;
    public Rect rHudBullet;

    public GUIStyle styleHint;

    private void Start()
    {
        this.audioSrc = GetComponent<AudioSource>();
        audioSrc.loop = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) fireShip();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (idWeapon <= 0)
                idWeapon = weapons.Length - 1;
            else
                idWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (idWeapon >= weapons.Length - 1)
                idWeapon = 0;
            else
                idWeapon++;
        }
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

    private void OnGUI()
    {
        GUI.Box(rHudHint, hudHint, styleHint);
        GUI.DrawTexture(rHudBullet, weapons[idWeapon].iconHud);
    }
}

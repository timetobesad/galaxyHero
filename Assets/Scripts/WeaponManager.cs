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

    public AudioClip clipHint;

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
        for (int i = 0; i < weapons[idWeapon].Cannons.Length; i++)
        {
            GameObject shell = GameObject.Instantiate(weapons[idWeapon].BulletPref, weapons[idWeapon].Cannons[i].position, weapons[idWeapon].Cannons[i].rotation);
            shell.GetComponent<Bullet>().hit = hitEnemy;

            if (weapons[i].Clip)
            {
                audioSrc.Stop();
                audioSrc.clip = weapons[idWeapon].Clip;
                audioSrc.Play();
            }
        }
    }

    private void OnGUI()
    {
        GUI.Box(rHudHint, hudHint, styleHint);
        GUI.DrawTexture(rHudBullet, weapons[idWeapon].IconHud);
    }

    public void hitEnemy(GameObject hitObj, Bullet bullet)
    {
        if (hitObj.tag == bullet.TagEnemy)
        {
            Enemy enemy = hitObj.GetComponent<Enemy>();
            enemy.makeDammage(bullet.Dammage);

            if (audioSrc.isPlaying && audioSrc.clip.name == clipHint.name) return;

            audioSrc.Stop();
            audioSrc.clip = clipHint;
            audioSrc.Play();
        }
    }
}

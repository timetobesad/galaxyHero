using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour, Ship
{
    private int healthVal = 100;
    private int armourVal = 0;

    public Texture healthTexture;
    public Texture armourTexture;

    public Rect rHeathHud;
    public Rect rArmourHud;

    public GUIStyle styleHud;

    public EndGame endGame;

    public float timeShowBloodScr;

    public ScreenEffect effectMng;

    private Coroutine flashEffCrt;

    public bool IsAlive
    {
        get { return this.healthVal > 0; }
    }

    private void OnGUI()
    {
        GUI.DrawTexture(rHeathHud, healthTexture);
        GUI.DrawTexture(rArmourHud, armourTexture);

        GUI.Box(rHeathHud, healthVal.ToString(), styleHud);
        GUI.Box(rArmourHud, armourVal.ToString(), styleHud);
    }

    public void makeDamge(int damage)
    {
        healthVal -= damage;

        if (healthVal < 0)
            healthVal = 0;
       else
            enBloodScreen();
    }

    public void destoryEnemy()
    {
        endGame.enabled = true;
    }

    private void enBloodScreen()
    {
        CancelInvoke();

        effectMng.enbBloodScreen();
        Invoke("disBloodScreen", timeShowBloodScr);
    }

    private void disBloodScreen()
    {
        effectMng.disBloodScreen();
    }
}
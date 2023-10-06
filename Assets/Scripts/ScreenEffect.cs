using System.Collections;
using UnityEngine;

public class ScreenEffect : MonoBehaviour
{
    public float minAlphaDef = 0.2f;

    public flashInfo flash;

    public Texture flashTexture;

    [SerializeField]
    private float alpha;
    [SerializeField]
    private float minAlpha;
    [SerializeField]
    private bool isFlashing = false;

    private float Alpha
    {
        get { return this.alpha; }

        set
        {
            alpha = value;

            if (alpha <= minAlpha)
            {
                if (alpha <= 0.0f && flashEffCrt != null)
                {
                    StopCoroutine(flashEffCrt);
                    flashEffCrt = null;
                }
                else
                    flash.dirr = flashInfo.dirrection.inc;
            }
            else if (alpha >= 1)
                flash.dirr = flashInfo.dirrection.dec;
        }
    }

    private Coroutine flashEffCrt;

    private void Start()
    {
        minAlpha = minAlphaDef;
    }

    public void OnGUI()
    {
        drawFlashScreen(new Rect(0, 0, Screen.width, Screen.height), flashTexture, alpha);
    }

    public void enbBloodScreen()
    {
        isFlashing = true;

        if (flashEffCrt == null)
        {
            flashEffCrt = StartCoroutine(changeAlphaColor());
            alpha = 0.1f;
            minAlpha = minAlphaDef;
        }
    }

    public void disBloodScreen()
    {
        minAlpha = 0;
        isFlashing = false;
    }

    public void drawFlashScreen(Rect rect, Texture texture, float alpha)
    {
        Color oldCol = GUI.color;
        Color col = new Color(oldCol.r, oldCol.g, oldCol.b, Alpha);

        GUI.color = col;

        GUI.DrawTexture(rect, texture);

        GUI.color = oldCol;
    }

    public IEnumerator changeAlphaColor()
    {
        while (isFlashing || alpha > 0.0f)
        {
            if (flash.dirr == flashInfo.dirrection.inc)
                Alpha += flash.speed;
            else
                Alpha -= flash.speed;

            yield return new WaitForSeconds(flash.delay);
        }
    }
}



[System.Serializable]
public struct flashInfo
{
    public float delay;
    public float speed;
    public enum dirrection
    {
        inc, dec
    }

    public dirrection dirr;
}
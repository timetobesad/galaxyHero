using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public ScoreManager score;
    public AudioSource bgAudioSrc;

    public Rect rHintEndGame;
    public Rect rMenuBtn;
    public Rect rNewGame;

    public GUIStyle style;
    public GUIStyle styleBtn;

    public Texture bgTexture;

    public int menuSceneId;

    private void OnEnable()
    {
        Time.timeScale = 0;
        bgAudioSrc.Stop();
    }

    public void OnGUI()
    {
        GUI.depth = 144;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), bgTexture);
        GUI.Box(rHintEndGame, string.Format("Game over, you score result {0} c: \n\n Retry level ?", score.Points), style);

        if (GUI.Button(rMenuBtn, "Main menu", styleBtn))
            SceneManager.LoadScene(menuSceneId);

        if (GUI.Button(rNewGame, "Retry", styleBtn))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        GUI.depth = 1;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UI_EndGameMenu : MonoBehaviour
{
    public Text message;

    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if (gm.vidas > 0)
        {
            message.text = "Você Ganhou!!!";
        }
        else
        {
            message.text = "Você já era!!";
        }
    }

    public void BackToMainMenu()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }

    public void RestartGame()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}

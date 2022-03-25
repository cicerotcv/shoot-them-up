using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    Text textComp;

    GameManager gm;

    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        textComp.text = $"Score: {gm.score}";
    }
}

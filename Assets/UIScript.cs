using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public static UIScript instance; // wird gebraucht zum kommunizierung der daten von den anderen Scripts

    public Text Score;
    public Text Life;
    public Text Stage;

    void Awake()
    {
        instance = this;
    }

    // Text verändert sich je nach dem was passiert
    public void UpdateScoreText (int amount)
    {
        Score.text = amount.ToString("D9"); //steht für 9 Dezimalstellen
    }

    public void UpdateLifeText(int amount)
    {
        Life.text = amount.ToString("D2"); //steht für 2 Dezimalstellen
    }

    public void ShowStageText(int amount)
    {
        Stage.text = "Stage " + amount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UiScript : MonoBehaviour
{

    public static UiScript instance; // wird gebraucht zum kommunizierung der daten von den anderen Scripts


    public Text scoreText;
    public Text lifeText;
    public Text stageText;
   // public Text rocketslefttext;

    void Awake()
    {
        instance = this;
    }

  /*  public void UpdateRocketsText(int amount)
    {

        rocketslefttext.text = "x " + amount.ToString("D2");
    }
    */
     // Text verändert sich je nach dem was passiert
     public void UpdateScoreText(int amount)
     {

        scoreText.text = amount.ToString("D9"); //steht für 9 Dezimalstellen
     }

    public void UpdateLifeText(int amount)
    {
        lifeText.text = "x" + amount.ToString("D2"); //steht für 2 Dezimalstellen
    }

    public void ShowStageText(int amount)
    {
        stageText.gameObject.SetActive(true);
        stageText.text = "Stage " + amount;

        Invoke("DeactivateStagetext", 100f);
    }

    void DeactivateStagetext()
    {
        stageText.gameObject.SetActive(false);
        CancelInvoke("DeactivateStagetext");
    }

}

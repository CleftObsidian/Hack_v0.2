using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Text scoreText;
    public Text comboText;
    public Text multiScoreText;
    public Text optimumText;
    public Text rateText;
    public bool createMode;

    public Text perText;
    public Text greText;
    public Text gooText;
    public Text badText;
    public Text misText;

    private int score = 0;
    private int combo = 0;
    private int multiScore;
    private float rate;

    private int perNum = 0;
    private int greNum = 0;
    private int gooNum = 0;
    private int badNum = 0;
    private int misNum = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

	void Start () {
        score = 0;
        scoreText.text = "" + score;

        combo = 0;
        comboText.text = combo + "";

        multiScore = 1;
        multiScoreText.text = "";

        optimumText.text = "";

        rateText.text = "";
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        optimumText.text = "MISS";
        misNum++;
        optimumText.color = new Color(255, 0, 0);

        ResetCombo();
    }

    public void AddScore(int newScore)
    {
        score += newScore * multiScore;

        switch (newScore)
        {
            case 0:
                optimumText.text = "MISS";
                misNum++;
                optimumText.color = new Color(255, 0, 0);
                break;
            case 30:
                optimumText.text = "BAD";
                badNum++;
                optimumText.color = new Color(95, 0, 255);
                break;
            case 50:
                optimumText.text = "GOOD";
                gooNum++;
                optimumText.color = new Color(0, 255, 255);
                break;
            case 80:
                optimumText.text = "GREAT";
                greNum++;
                optimumText.color = new Color(0, 255, 0);
                break;
            case 100:
                optimumText.text = "PERPECT";
                perNum++;
                optimumText.color = new Color(255, 255, 0);
                break;
            default:
                optimumText.text = "";
                break;
        }

        UIUpdate();
    }

    public void AddCombo()
    {
        combo++;

        if (combo >= 40)
        {
            multiScore = 5;
        }
        else if (combo >= 30)
        {
            multiScore = 4;
        }
        else if (combo >= 20)
        {
            multiScore = 3;
        }
        else if (combo >= 10)
        {
            multiScore = 2;
        }
        else
        {
            multiScore = 1;
        }

        UIUpdate();
    }

    public void ResetCombo() // MISS
    {
        combo = 0;

        UIUpdate();
    }

    public void rateCal()
    {
        int noteAll = perNum + greNum + gooNum + badNum + misNum;
        rate = (perNum + 0.8f * greNum + 0.5f * gooNum + 0.3f * badNum + 0f * misNum) / noteAll * 100;
    }

    public void UIUpdate()
    {
        scoreText.text = "" + score;
        comboText.text = combo + "";

        if (multiScore > 1)
        {
            multiScoreText.text = "Score X" + multiScore;
        }
        else
        {
            multiScoreText.text = "";
        }

        rateCal();
        rateText.text = rate.ToString("F") + "%";

        perText.text = perNum + " Perpect";
        greText.text = greNum + " Great";
        gooText.text = gooNum + " Good";
        badText.text = badNum + " Bad";
        misText.text = misNum + " Miss";
    }
}

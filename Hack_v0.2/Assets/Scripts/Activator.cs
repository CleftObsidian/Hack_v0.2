using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public GameObject line;
    public KeyCode key; // 입력 버튼
    public GameObject n; // createMode에서 생성될 노트

    private bool isActive = false; // 판정선에 닿았는지 체크
    private GameObject note; // 노트
    private int score;
    private float checkPos;
    private bool isMiss;

    void Start () {
        checkPos = transform.position.y;
    }

    void Update () {
        if (GameManager.instance.createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                line.SetActive(true);
            }

            if (Input.GetKeyUp(key))
            {
                line.SetActive(false);
            }

            if (Input.GetKeyDown(key) && isActive)
            {
                AudioManager.instance.PlayNoteSound();
                EffectManager.instance.PlayNoteParticle(transform.position);
                Destroy(note);
                isMiss = OptimumCheck();
                GameManager.instance.AddScore(score);
                if (!isMiss)
                    GameManager.instance.AddCombo();
                isActive = false;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        isActive = true;

        if (other.gameObject.tag == "Note")
        {
            note = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isActive = false;
    }

    bool OptimumCheck()
    {
        float notePos = note.transform.position.y;
        float distance = Mathf.Abs(notePos - checkPos);

        if (distance > 1.1f)      // MISS
        {
            score = 0;
            GameManager.instance.ResetCombo();
            return true;
        }
        else if (distance > 0.9f) // BAD
        {
            score = 30;
            return false;
        }
        else if (distance > 0.6f) // GOOD
        {
            score = 50;
            return false;
        }
        else if (distance > 0.3f) // GREAT
        {
            score = 80;
            return false;
        }
        else                      // PERPECT
        {
            score = 100;
            return false;
        }
    }
}

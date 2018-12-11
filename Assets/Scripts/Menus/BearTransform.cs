using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BearTransform : MonoBehaviour {

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite spriteGood;
    [SerializeField] Sprite spriteBad;
    [SerializeField] TextMeshProUGUI text;

    bool time1 = true;
    bool time2 = true;
    bool time3 = true;

	// Use this for initialization
	void Start () {
        spriteRenderer.sprite = spriteGood;
        text.text = "You wont hug me?";
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad >=3f && time1)
        {
            text.text = "";
            spriteRenderer.sprite = null;
            time1 = false;
        }

        if (Time.timeSinceLevelLoad >= 5f && time2)
        {
            text.text = "YOU'LL REGRET THIS MOVE!!!";
            spriteRenderer.sprite = spriteBad;
            time2 = false;
        }

        if (Time.timeSinceLevelLoad >= 8f && time3)
        {
            SceneManager.LoadScene("Game");
            time3 = false;
        }
	}
}

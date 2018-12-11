using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Wave0 : MonoBehaviour {

    [SerializeField] GameObject dollCute;
    [SerializeField] GameObject babyBearCute;
    [SerializeField] TextMeshProUGUI textWave;

    float dollSpeed = 1;
    float babyBearSpeed = 2;

    #region Enemies in Wave
    GameObject enemy1;
    GameObject enemy2;
    GameObject enemy3;
    GameObject enemy4;
    GameObject enemy5;
    GameObject enemy6;
    #endregion;

    #region Bools for time

    #endregion;

    public float DollSpeed
    {
        get
        {
            return dollSpeed;
        }
        set
        {
            dollSpeed = value;
        }
    }

    public float BabyBearSpeed
    {
        get
        {
            return babyBearSpeed;
        }
        set
        {
            babyBearSpeed = value;
        }
    }

    enum WaveManager
    {
        WAVE_START,
        WAVE,
        WAVE_END,
    }

    WaveManager waveManager;

    bool calledOnceInFunction;
    float startFunctionTime;

    // Use this for initialization
    void Start () {
        waveManager = WaveManager.WAVE_START;
		
	}
	
	// Update is called once per frame
	void Update () {
		
        switch (waveManager)
        {
            case WaveManager.WAVE_START:
                WaveStart();
                break;
            case WaveManager.WAVE:
                Wave();
                break;
            case WaveManager.WAVE_END:
                WaveEnd();
                break;
        }
	}

    void WaveStart()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            textWave.text = "Wave 0";
            calledOnceInFunction = false;
        }
        if (Time.timeSinceLevelLoad -startFunctionTime >= 3f)
        {
            textWave.text = "";
            waveManager = WaveManager.WAVE;
            calledOnceInFunction = true;
        }
    }

    void Wave()
    {
        if (calledOnceInFunction)
        {
            //dollSpeed = 1;
            //babyBearSpeed = 2;
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
            enemy1 = Instantiate(dollCute, new Vector3(-11f, dollCute.transform.position.y, 0), Quaternion.identity);
            enemy2 = Instantiate(dollCute, new Vector3(11f, dollCute.transform.position.y, 0), Quaternion.identity);
            enemy3 = Instantiate(babyBearCute, new Vector3(-12f, -2f, 0), Quaternion.identity);
            enemy4 = Instantiate(babyBearCute, new Vector3(12f, -2f, 0), Quaternion.identity);
            enemy5 = Instantiate(babyBearCute, new Vector3(-12f, 2f, 0), Quaternion.identity);
            enemy6 = Instantiate(babyBearCute, new Vector3(12f, 2f, 0), Quaternion.identity);

        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null &&
            enemy5 == null && enemy6 == null)
        {
            waveManager = WaveManager.WAVE_END;
            calledOnceInFunction = false;
        }
    }

    void WaveEnd()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
            textWave.text = "You passed Wave 0!";
        }
        if (Time.timeSinceLevelLoad -startFunctionTime >= 3f)
        {
            calledOnceInFunction = true;
            SceneManager.LoadScene("BearTransform");
        }
    }
}

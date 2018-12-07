using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

    [SerializeField] GameObject dollEnemy;
    [SerializeField] GameObject babyBearEnemy;

    float startFunctionTime;

    #region Enemies in Wave
    GameObject enemy1;
    GameObject enemy2;
    GameObject enemy3;
    GameObject enemy4;
    GameObject enemy5;
    GameObject enemy6;
    GameObject enemy7;
    GameObject enemy8;
    GameObject enemy9;
    GameObject enemy10;
    #endregion

    enum WaveLevel
    {
        WAVE_1,
        WAVE_2,
        WAVE_3,
    }

    enum ActualWave
    {
        WAVE_START,
        WAVE,
        WAVE_END,
    }

    WaveLevel waveLevel;
    ActualWave actualWave;

    bool calledOnceInFunction = true;

    void Start () {
        waveLevel = WaveLevel.WAVE_1;
	}
	
	void Update () {

        switch (actualWave)
        {
            case ActualWave.WAVE_START:
                WaveStart();
                break;
            case ActualWave.WAVE:
                SwitchWaveLevel();
                break;
            case ActualWave.WAVE_END:
                WaveEnd();
                break;
        }
	}
    void SwitchWaveLevel()
    {
        switch (waveLevel)
        {
            case WaveLevel.WAVE_1:
                Wave1();
                break;
            case WaveLevel.WAVE_2:
                break;
            case WaveLevel.WAVE_3:
                break;
        }
    }

    void WaveStart()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
        }
        if (Time.timeSinceLevelLoad - startFunctionTime >= 3f)
        {
            actualWave = ActualWave.WAVE;
            calledOnceInFunction = true;
        }
    }

    void Wave1()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
            enemy1 = Instantiate(dollEnemy);
            enemy2 = Instantiate(babyBearEnemy);
            enemy3 = Instantiate(babyBearEnemy);
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
        }


    }

    void WaveEnd()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
        }
        if (Time.timeSinceLevelLoad - startFunctionTime >= 3f)
        {
            actualWave = ActualWave.WAVE;
            calledOnceInFunction = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

    [SerializeField] GameObject dollEnemy;
    [SerializeField] GameObject babyBearEnemy;

    float startFunctionTime;

    float LeftXSpawnerPosition = -11f;
    float RightXSpawnerPosition = 11f;

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

    #region Bools for time
    bool timeWave1 = true;
    bool timeWave2 = true;
    bool timeWave3 = true;
    bool timeWave4 = true;
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
                Wave2();
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
            enemy1 = Instantiate(dollEnemy, new Vector3(-11f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy2 = Instantiate(babyBearEnemy, new Vector3(-12f, 3.5f, 0), Quaternion.identity);
            enemy3 = Instantiate(babyBearEnemy, new Vector3(12f, -2f, 0), Quaternion.identity);
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
        }


    }

    void Wave2()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
            enemy1 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy2 = Instantiate(babyBearEnemy, new Vector3(-12f, 2.5f, 0), Quaternion.identity);
            enemy3 = Instantiate(babyBearEnemy, new Vector3(12f, 2.5f, 0), Quaternion.identity);
            enemy4 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 5f && timeWave1)
        {

            enemy5 = Instantiate(babyBearEnemy, new Vector3(12f, 3.5f, 0), Quaternion.identity);
            timeWave1 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 8f && timeWave2)
        {

            enemy6 = Instantiate(babyBearEnemy, new Vector3(-12f, -2f, 0), Quaternion.identity);
            timeWave2 = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null && enemy6 == null)
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
            switch (waveLevel)
            {
                case WaveLevel.WAVE_1:
                    waveLevel = WaveLevel.WAVE_2;
                    break;
                case WaveLevel.WAVE_2:
                    waveLevel = WaveLevel.WAVE_1;
                    break;
                case WaveLevel.WAVE_3:
                    break;
            }
            actualWave = ActualWave.WAVE_START;
            calledOnceInFunction = true;
        }
    }
}

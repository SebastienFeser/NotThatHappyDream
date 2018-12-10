using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Waves : MonoBehaviour
{

    [SerializeField] GameObject dollEnemy;
    [SerializeField] GameObject babyBearEnemy;
    [SerializeField] GameObject bearBoss;

    [SerializeField] TextMeshProUGUI textWaves;

    #region Used Outside Values
    float dollSpeed;
    float babyBearSpeed;
    float bearBossSpeedHorizontal;
    float bearBossSpeedVertical;
    float bearBossWaitingTime;

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

    public float BearBossSpeedHorizontal
    {
        get
        {
            return bearBossSpeedHorizontal;
        }
        set
        {
            bearBossSpeedHorizontal = value;
        }
    }
    public float BearBossSpeedVertical
    {
        get
        {
            return bearBossSpeedVertical;
        }
        set
        {
            bearBossSpeedVertical = value;
        }
    }
    public float BearBossWaitingTime
    {
        get
        {
            return bearBossWaitingTime;
        }
        set
        {
            bearBossWaitingTime = value;
        }
    }


    #endregion


    float LeftXSpawnerPosition = -11f;
    float RightXSpawnerPosition = 11f;
    int waveCount = 1;

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
    GameObject enemy11;
    GameObject enemy12;
    GameObject enemy13;
    GameObject enemy14;
    GameObject enemy15;
    GameObject enemy16;
    GameObject enemy17;
    #endregion

    #region Bools for time
    bool timeWave1 = true;
    bool timeWave2 = true;
    bool timeWave3 = true;
    bool timeWave4 = true;
    bool timeWave5 = true;
    bool timeWave6 = true;
    bool timeWave7 = true;
    bool timeWave8 = true;
    bool timeWave9 = true;
    bool timeWave10 = true;
    #endregion

    enum WaveLevel
    {
        WAVE_1,
        WAVE_2,
        WAVE_3,
        WAVE_4,
        WAVE_5,
        WAVE_6,
        WAVE_7,
        WAVE_8,
        WAVE_9,
        WAVE_10,
        WAVE_11,
        WAVE_12,
        WAVE_13,
        WAVE_14,
        WAVE_15,
        VICTORY,
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
    float startFunctionTime;

    void Start()
    {
        waveLevel = WaveLevel.WAVE_1;
        bearBossSpeedHorizontal = 6f;
        bearBossSpeedVertical = 3f;
        bearBossWaitingTime = 2f;
    }

    void Update()
    {

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
                Wave3();
                break;
            case WaveLevel.WAVE_4:
                Wave4();
                break;
            case WaveLevel.WAVE_5:
                Wave5();
                break;
            case WaveLevel.WAVE_6:
                Wave6();
                break;
            case WaveLevel.WAVE_7:
                Wave7();
                break;
            case WaveLevel.WAVE_8:
                Wave8();
                break;
            case WaveLevel.WAVE_9:
                Wave9();
                break;
            case WaveLevel.WAVE_10:
                Wave10();
                break;
            case WaveLevel.WAVE_11:
                Wave11();
                break;
            case WaveLevel.WAVE_12:
                Wave12();
                break;
            case WaveLevel.WAVE_13:
                Wave13();
                break;
            case WaveLevel.WAVE_14:
                Wave14();
                break;
            case WaveLevel.WAVE_15:
                Wave15();
                break;
            case WaveLevel.VICTORY:
                Victory();
                break;
        }
    }

    void WaveStart()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            textWaves.text = "Wave " + waveCount;
            calledOnceInFunction = false;
        }
        if (Time.timeSinceLevelLoad - startFunctionTime >= 3f)
        {

            textWaves.text = "";
            actualWave = ActualWave.WAVE;
            calledOnceInFunction = true;
        }
    }

    void Wave1()
    {
        if (calledOnceInFunction)
        {
            dollSpeed = 1;
            babyBearSpeed = 3;
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
            dollSpeed = 1.5f;
            babyBearSpeed = 4f;
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

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null && enemy6 == null && Time.timeSinceLevelLoad - startFunctionTime >= 8.5f)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
            timeWave1 = true;
            timeWave2 = true;
        }


    }

    void Wave3()
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

        if (Time.timeSinceLevelLoad - startFunctionTime >= 5f && timeWave2)
        {
            enemy5 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy6 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            timeWave2 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 8f && timeWave3)
        {

            timeWave3 = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null && enemy6 == null && Time.timeSinceLevelLoad - startFunctionTime >= 8.5f)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
            timeWave1 = true;
            timeWave2 = true;
            timeWave3 = true;
        }


    }

    void Wave4()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
            enemy1 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy2 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy3 = Instantiate(babyBearEnemy, new Vector3(-12f, -1f, 0), Quaternion.identity);
            enemy4 = Instantiate(babyBearEnemy, new Vector3(12f, -1f, 0), Quaternion.identity);

        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 1f && timeWave1)
        {
            enemy5 = Instantiate(babyBearEnemy, new Vector3(-12f, 0f, 0), Quaternion.identity);
            enemy6 = Instantiate(babyBearEnemy, new Vector3(12f, 0f, 0), Quaternion.identity);

            timeWave1 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 2f && timeWave2)
        {
            enemy7 = Instantiate(babyBearEnemy, new Vector3(-12f, 1f, 0), Quaternion.identity);
            enemy8 = Instantiate(babyBearEnemy, new Vector3(12f, 1f, 0), Quaternion.identity);

            timeWave2 = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null && enemy6 == null && enemy7 == null && enemy8 == null && Time.timeSinceLevelLoad - startFunctionTime >= 2.5f)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
            timeWave1 = true;
            timeWave2 = true;
        }
    }

    void Wave5()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            enemy1 = Instantiate(bearBoss, new Vector3(-15f, 0, 0), Quaternion.identity);
            enemy2 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy3 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            calledOnceInFunction = false;
        }

        if (enemy2 == null && enemy3 == null && enemy1 != null && timeWave1)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            timeWave1 = false;
        };

        if (Time.timeSinceLevelLoad - startFunctionTime >= 10f && enemy2 == null && enemy3 == null && enemy1 != null)
        {
            enemy2 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy3 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);

            timeWave1 = true;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
            timeWave1 = true;
        }
    }

    void Wave6()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            enemy1 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy2 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy3 = Instantiate(babyBearEnemy, new Vector3(-12f, 3f, 0), Quaternion.identity);
            enemy4 = Instantiate(babyBearEnemy, new Vector3(12f, 3f, 0), Quaternion.identity);
            enemy5 = Instantiate(babyBearEnemy, new Vector3(-12f, -2f, 0), Quaternion.identity);
            enemy6 = Instantiate(babyBearEnemy, new Vector3(12f, -2f, 0), Quaternion.identity);
            calledOnceInFunction = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 2f && timeWave1)
        {
            enemy7 = Instantiate(babyBearEnemy, new Vector3(-12f, 0.5f, 0), Quaternion.identity);
            enemy8 = Instantiate(babyBearEnemy, new Vector3(12f, 0.5f, 0), Quaternion.identity);
            timeWave1 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 5f && timeWave2)
        {
            enemy9 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy10 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);

            timeWave2 = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null &&
            enemy6 == null && enemy7 == null && enemy8 == null && enemy9 == null && enemy10 == null && Time.timeSinceLevelLoad - startFunctionTime >= 5.5f)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
            timeWave1 = true;
            timeWave2 = true;
        }
    }

    void Wave7()
    {
        if (calledOnceInFunction)
        {
            dollSpeed = 4f;
            enemy1 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 1f && timeWave1)
        {
            enemy2 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            timeWave1 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 2f && timeWave2)
        {
            enemy3 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            timeWave2 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 3f && timeWave3)
        {
            enemy4 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy5 = Instantiate(babyBearEnemy, new Vector3(-12f, 0.5f, 0), Quaternion.identity);
            enemy6 = Instantiate(babyBearEnemy, new Vector3(12f, 0.5f, 0), Quaternion.identity);

            timeWave3 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 4f && timeWave4)
        {
            enemy7 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            timeWave4 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 5f && timeWave5)
        {
            enemy8 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            timeWave5 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 6f && timeWave6)
        {
            enemy9 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            timeWave6 = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null
            && enemy6 == null && enemy7 == null && enemy8 == null && enemy9 == null && Time.timeSinceLevelLoad - startFunctionTime >= 6.5f)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
            timeWave1 = true;
            timeWave2 = true;
            timeWave3 = true;
            timeWave4 = true;
            timeWave5 = true;
            timeWave6 = true;
        }
    }

    void Wave8()
    {
        if (calledOnceInFunction)
        {
            dollSpeed = 3f;
            BabyBearSpeed = 6f;
            enemy1 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy2 = Instantiate(babyBearEnemy, new Vector3(-12f, -2f, 0), Quaternion.identity);
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 1f && timeWave1)
        {
            enemy3 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy4 = Instantiate(babyBearEnemy, new Vector3(12f, -1f, 0), Quaternion.identity);

            timeWave1 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 2f && timeWave2)
        {
            enemy5 = Instantiate(babyBearEnemy, new Vector3(-12f, 0, 0), Quaternion.identity);

            timeWave2 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 3f && timeWave3)
        {
            enemy6 = Instantiate(babyBearEnemy, new Vector3(12f, 1f, 0), Quaternion.identity);
            timeWave3 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 4f && timeWave4)
        {
            enemy7 = Instantiate(babyBearEnemy, new Vector3(-12f, 2f, 0), Quaternion.identity);
            timeWave4 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 5f && timeWave5)
        {
            enemy8 = Instantiate(babyBearEnemy, new Vector3(12f, 3f, 0), Quaternion.identity);
            timeWave5 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 6f && timeWave6)
        {
            enemy9 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            timeWave6 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 7f && timeWave7)
        {
            enemy10 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            timeWave7 = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null &&
            enemy6 == null && enemy7 == null && enemy8 == null && enemy9 == null && enemy10 == null
            && Time.timeSinceLevelLoad - startFunctionTime >= 7.5f)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
            timeWave1 = true;
            timeWave2 = true;
            timeWave3 = true;
            timeWave4 = true;
            timeWave5 = true;
            timeWave6 = true;
            timeWave7 = true;
        }
    }

    void Wave9()
    {
        if (calledOnceInFunction)
        {
            enemy1 = Instantiate(babyBearEnemy, new Vector3(-12f, 3f, 0), Quaternion.identity);
            enemy2 = Instantiate(babyBearEnemy, new Vector3(-12f, 1f, 0), Quaternion.identity);
            enemy3 = Instantiate(babyBearEnemy, new Vector3(-12f, 0f, 0), Quaternion.identity);
            enemy4 = Instantiate(babyBearEnemy, new Vector3(-12f, -2f, 0), Quaternion.identity);
            enemy5 = Instantiate(babyBearEnemy, new Vector3(12f, 3f, 0), Quaternion.identity);
            enemy6 = Instantiate(babyBearEnemy, new Vector3(12f, 1f, 0), Quaternion.identity);
            enemy7 = Instantiate(babyBearEnemy, new Vector3(12f, 0f, 0), Quaternion.identity);
            enemy8 = Instantiate(babyBearEnemy, new Vector3(12f, -2f, 0), Quaternion.identity);
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null
             && enemy5 == null && enemy6 == null && enemy7 == null && enemy8 == null)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
        }
    }

    void Wave10()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            enemy1 = Instantiate(bearBoss, new Vector3(-15f, 0, 0), Quaternion.identity);
            enemy2 = Instantiate(bearBoss, new Vector3(15f, 0, 0), Quaternion.identity);
            enemy3 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy4 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            calledOnceInFunction = false;
        }

        if (enemy3 == null && enemy4 == null && enemy1 != null && enemy2 != null && timeWave1)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            timeWave1 = false;
        };

        if (Time.timeSinceLevelLoad - startFunctionTime >= 10f && enemy3 == null && enemy4 == null && enemy1 != null && enemy2 != null)
        {
            enemy3 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy4 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);

            timeWave1 = true;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
            timeWave1 = true;
        }
    }

    void Wave11()
    {
        if (calledOnceInFunction)
        {
            babyBearSpeed = 8f;
            enemy1 = Instantiate(babyBearEnemy, new Vector3(-12f, 3.5f, 0), Quaternion.identity);
            enemy2 = Instantiate(babyBearEnemy, new Vector3(12f, 3.5f, 0), Quaternion.identity);
            enemy3 = Instantiate(babyBearEnemy, new Vector3(-12f, -2f, 0), Quaternion.identity);
            enemy4 = Instantiate(babyBearEnemy, new Vector3(12f, -2f, 0), Quaternion.identity);
            enemy5 = Instantiate(babyBearEnemy, new Vector3(-12f, 0.5f, 0), Quaternion.identity);
            enemy6 = Instantiate(babyBearEnemy, new Vector3(12f, 0.5f, 0), Quaternion.identity);
            enemy7 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy8 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            calledOnceInFunction = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null &&
            enemy6 == null && enemy7 == null && enemy8 == null && enemy9 == null && enemy10 == null)
        {
            actualWave = ActualWave.WAVE_END;
            calledOnceInFunction = true;
        }

    }

    void Wave12()
    {
        if (calledOnceInFunction)
        {
            DollSpeed = 4f;
            enemy1 = Instantiate(babyBearEnemy, new Vector3(12f, 3.5f, 0), Quaternion.identity);
            enemy2 = Instantiate(babyBearEnemy, new Vector3(-12f, -3f, 0), Quaternion.identity);
            enemy3 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 1f && timeWave1)
        {
            enemy4 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);

            timeWave1 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 2f && timeWave2)
        {
            enemy5 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy6 = Instantiate(babyBearEnemy, new Vector3(-12f, -3f, 0), Quaternion.identity);
            timeWave2 = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null
             && enemy5 == null && enemy6 == null && Time.timeSinceLevelLoad - startFunctionTime >= 2.5f)
        {
            actualWave = ActualWave.WAVE_END;
            timeWave1 = true;
            timeWave2 = true;
            calledOnceInFunction = true;
        }
    }

    void Wave13()
    {
        if (calledOnceInFunction)
        {
            enemy1 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy2 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy3 = Instantiate(babyBearEnemy, new Vector3(12f, 3f, 0), Quaternion.identity);
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 1 && timeWave1)
        {
            enemy4 = Instantiate(babyBearEnemy, new Vector3(12f, 2f, 0), Quaternion.identity);
            timeWave1 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 2 && timeWave2)
        {
            enemy5 = Instantiate(babyBearEnemy, new Vector3(12f, 1f, 0), Quaternion.identity);
            timeWave2 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 3 && timeWave3)
        {
            enemy6 = Instantiate(babyBearEnemy, new Vector3(12f, 0f, 0), Quaternion.identity);
            enemy7 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy8 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            timeWave3 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 4 && timeWave4)
        {
            enemy9 = Instantiate(babyBearEnemy, new Vector3(12f, -1f, 0), Quaternion.identity);
            timeWave4 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 5 && timeWave5)
        {
            enemy10 = enemy6 = Instantiate(babyBearEnemy, new Vector3(12f, -3f, 0), Quaternion.identity);
            timeWave5 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 6 && timeWave6)
        {
            enemy11 = Instantiate(babyBearEnemy, new Vector3(12f, -3f, 0), Quaternion.identity);
            timeWave6 = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null &&
            enemy6 == null && enemy7 == null && enemy8 == null && enemy9 == null && enemy10 == null &&
            enemy11 == null && Time.timeSinceLevelLoad - startFunctionTime >= 6.5f)
        {
            actualWave = ActualWave.WAVE_END;
            timeWave1 = true;
            timeWave2 = true;
            timeWave3 = true;
            timeWave4 = true;
            timeWave5 = true;
            timeWave6 = true;
            calledOnceInFunction = true;
        }

    }

    void Wave14()
    {
        if (calledOnceInFunction)
        {
            enemy1 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy2 = Instantiate(babyBearEnemy, new Vector3(-12f, 3f, 0), Quaternion.identity);
            enemy3 = Instantiate(babyBearEnemy, new Vector3(12f, 3f, 0), Quaternion.identity);
            enemy4 = Instantiate(babyBearEnemy, new Vector3(-12f, -3f, 0), Quaternion.identity);
            enemy5 = Instantiate(babyBearEnemy, new Vector3(12f, -3f, 0), Quaternion.identity);
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 1f && timeWave1)
        {
            enemy6 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy7 = Instantiate(babyBearEnemy, new Vector3(-12f, 2f, 0), Quaternion.identity);
            enemy8 = Instantiate(babyBearEnemy, new Vector3(12f, 2f, 0), Quaternion.identity);
            enemy9 = Instantiate(babyBearEnemy, new Vector3(-12f, -2f, 0), Quaternion.identity);
            enemy10 = Instantiate(babyBearEnemy, new Vector3(12f, -2f, 0), Quaternion.identity);
            timeWave1 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 2f && timeWave2)
        {
            enemy11 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy12 = Instantiate(babyBearEnemy, new Vector3(-12f, 1f, 0), Quaternion.identity);
            enemy13 = Instantiate(babyBearEnemy, new Vector3(12f, 1f, 0), Quaternion.identity);
            enemy14 = Instantiate(babyBearEnemy, new Vector3(-12f, -1f, 0), Quaternion.identity);
            enemy15 = Instantiate(babyBearEnemy, new Vector3(12f, -1f, 0), Quaternion.identity);
            timeWave2 = false;
        }

        if (Time.timeSinceLevelLoad - startFunctionTime >= 3f && timeWave3)
        {
            enemy16 = Instantiate(babyBearEnemy, new Vector3(-12f, 0f, 0), Quaternion.identity);
            enemy17 = Instantiate(babyBearEnemy, new Vector3(12f, 0f, 0), Quaternion.identity);
            timeWave3 = false;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null &&
            enemy6 == null && enemy7 == null && enemy8 == null && enemy9 == null && enemy10 == null &&
            enemy11 == null && enemy12 == null && enemy13 == null && enemy14 == null && enemy15 == null &&
            enemy16 == null && enemy17 == null && Time.timeSinceLevelLoad - startFunctionTime >= 3.5f)
        {
            actualWave = ActualWave.WAVE_END;
            timeWave1 = true;
            timeWave2 = true;
            timeWave3 = true;
            calledOnceInFunction = true;
        }
    }

    void Wave15()
    {
        if (calledOnceInFunction)
        {
            bearBossSpeedVertical = 5f;
            bearBossSpeedHorizontal = 10f;
            bearBossWaitingTime = 0.5f;
            startFunctionTime = Time.timeSinceLevelLoad;
            enemy1 = Instantiate(bearBoss, new Vector3(-15f, 0, 0), Quaternion.identity);
            enemy2 = Instantiate(bearBoss, new Vector3(15f, 0, 0), Quaternion.identity);
            enemy3 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy4 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy5 = Instantiate(babyBearEnemy, new Vector3(-12f, 0, 0), Quaternion.identity);
            enemy6 = Instantiate(babyBearEnemy, new Vector3(12f, 0, 0), Quaternion.identity);
            enemy7 = Instantiate(babyBearEnemy, new Vector3(-12f, -3, 0), Quaternion.identity);
            enemy8 = Instantiate(babyBearEnemy, new Vector3(12f, -3, 0), Quaternion.identity);

            calledOnceInFunction = false;
        }

        if (enemy3 == null && enemy4 == null && enemy5 == null && enemy6 == null && enemy7 == null && enemy8 == null && enemy1 != null && enemy2 != null && timeWave1)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            timeWave1 = false;
        };

        if (Time.timeSinceLevelLoad - startFunctionTime >= 10f && enemy3 == null && enemy4 == null && enemy5 == null && enemy6 == null && enemy7 == null && enemy8 == null && enemy1 != null && enemy2 != null)
        {
            enemy3 = Instantiate(dollEnemy, new Vector3(-12f, dollEnemy.transform.position.y, 0), Quaternion.identity);
            enemy4 = Instantiate(dollEnemy, new Vector3(12f, dollEnemy.transform.position.y, 0), Quaternion.identity);

            timeWave1 = true;
        }

        if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null && enemy5 == null && enemy6 == null && enemy7 == null && enemy8 == null)
        {
            waveLevel = WaveLevel.VICTORY;
            calledOnceInFunction = true;
            timeWave1 = true;
        }
    }

    void Victory()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            textWaves.text = "You Won!!! Congratulations!";
            calledOnceInFunction = false;
        }
        if (Time.timeSinceLevelLoad - startFunctionTime >= 3f)
        {

            textWaves.text = "";
            //Load Victory
        }
    }

    void WaveEnd()
    {
        if (calledOnceInFunction)
        {
            startFunctionTime = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
            textWaves.text = "You passed Wave " + waveCount;
        }
        if (Time.timeSinceLevelLoad - startFunctionTime >= 3f)
        {
            switch (waveLevel)
            {
                case WaveLevel.WAVE_1:
                    waveLevel = WaveLevel.WAVE_2;
                    break;
                case WaveLevel.WAVE_2:
                    waveLevel = WaveLevel.WAVE_3;
                    break;
                case WaveLevel.WAVE_3:
                    waveLevel = WaveLevel.WAVE_4;
                    break;
                case WaveLevel.WAVE_4:
                    waveLevel = WaveLevel.WAVE_5;
                    break;
                case WaveLevel.WAVE_5:
                    waveLevel = WaveLevel.WAVE_6;
                    break;
                case WaveLevel.WAVE_6:
                    waveLevel = WaveLevel.WAVE_7;
                    break;
                case WaveLevel.WAVE_7:
                    waveLevel = WaveLevel.WAVE_8;
                    break;
                case WaveLevel.WAVE_8:
                    waveLevel = WaveLevel.WAVE_9;
                    break;
                case WaveLevel.WAVE_9:
                    waveLevel = WaveLevel.WAVE_10;
                    break;
                case WaveLevel.WAVE_10:
                    waveLevel = WaveLevel.WAVE_11;
                    break;
                case WaveLevel.WAVE_11:
                    waveLevel = WaveLevel.WAVE_12;
                    break;
                case WaveLevel.WAVE_12:
                    waveLevel = WaveLevel.WAVE_13;
                    break;
                case WaveLevel.WAVE_13:
                    waveLevel = WaveLevel.WAVE_14;
                    break;
                case WaveLevel.WAVE_14:
                    waveLevel = WaveLevel.WAVE_15;
                    break;
                case WaveLevel.WAVE_15:
                    waveLevel = WaveLevel.VICTORY;
                    break;
            }
            actualWave = ActualWave.WAVE_START;
            calledOnceInFunction = true;
            waveCount++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigBear : MonoBehaviour {

    [SerializeField] float bearLife;
    [SerializeField] float verticalSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float waitingTime;
    [SerializeField] Rigidbody2D enemyRigidBody;
    float timerCount;

    Vector2 leftSpawner = new Vector2(-5.5f, -9);
    Vector2 rightSpawner = new Vector2(5.5f, 9);

    #region Stop Positions
    Vector2 upLeft = new Vector2(-5.5f, 3);
    Vector2 downLeft = new Vector2(-5.5f, 0);
    Vector2 upRight = new Vector2(5.5f, 3);
    Vector2 downRight = new Vector2(5.5f, 0);
    #endregion


    enum BigBear
    {
        GO_UP,
        GO_DOWN,
        GO_LEFT,
        GO_RIGHT,
        WAITING,
        KILLED,
    }

    BigBear bigBearStates;
    BigBear bigBearStatesBackup;

    bool calledOnceInFunction = true;

    private void Start()
    {
        if (gameObject.transform.position.x < 0)
        {
            gameObject.transform.position = leftSpawner;
            bigBearStates = BigBear.GO_UP;
        }
        else
        {
            gameObject.transform.position = rightSpawner;
            bigBearStates = BigBear.GO_DOWN;
        }
    }

    void Update () {
		switch (bigBearStates)
        {
            case BigBear.GO_UP:
                GoUp();
                break;
            case BigBear.GO_DOWN:
                GoDown();
                break;
            case BigBear.GO_LEFT:
                GoLeft();
                break;
            case BigBear.GO_RIGHT:
                GoRight();
                break;
            case BigBear.WAITING:
                Waiting();
                break;
            case BigBear.KILLED:
                Killed();
                break;
        }
	}

    void GoUp()
    {
        if (calledOnceInFunction)
        {
            enemyRigidBody.velocity = new Vector2(0, verticalSpeed);
            calledOnceInFunction = false;
        }

        if (gameObject.transform.position.y >= upLeft.y)
        {
            bigBearStatesBackup = bigBearStates;
            bigBearStates = BigBear.WAITING;
            enemyRigidBody.velocity = new Vector2(0, 0);
            gameObject.transform.position = upLeft;
            calledOnceInFunction = true;
        }
    }

    void GoDown()
    {
        if (calledOnceInFunction)
        {
            enemyRigidBody.velocity = new Vector2(0, -verticalSpeed);
            calledOnceInFunction = false;
        }

        if (gameObject.transform.position.y >= downRight.y)
        {
            bigBearStatesBackup = bigBearStates;
            bigBearStates = BigBear.WAITING;
            enemyRigidBody.velocity = new Vector2(0, 0);
            gameObject.transform.position = downRight;
            calledOnceInFunction = true;
        }
    }

    void GoLeft()
    {
        if (calledOnceInFunction)
        {
            enemyRigidBody.velocity = new Vector2(-horizontalSpeed, 0);
            calledOnceInFunction = false;
        }

        if (gameObject.transform.position.y >= downLeft.y)
        {
            bigBearStatesBackup = bigBearStates;
            bigBearStates = BigBear.WAITING;
            enemyRigidBody.velocity = new Vector2(0, 0);
            gameObject.transform.position = downLeft;
            calledOnceInFunction = true;
        }
    }

    void GoRight()
    {
        if (calledOnceInFunction)
        {
            enemyRigidBody.velocity = new Vector2(horizontalSpeed, 0);
            calledOnceInFunction = false;
        }

        if (gameObject.transform.position.y >= upRight.y)
        {
            bigBearStatesBackup = bigBearStates;
            bigBearStates = BigBear.WAITING;
            enemyRigidBody.velocity = new Vector2(0, 0);
            gameObject.transform.position = upRight;
            calledOnceInFunction = true;
        }
    }

    void Waiting()
    {
        if (calledOnceInFunction)
        {
            timerCount = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
        }
        if (Time.timeSinceLevelLoad - timerCount >= )

    }

    void Killed()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBear : MonoBehaviour {
    [SerializeField] Transform enemyTransform;
    [SerializeField] Collider2D enemyCollider;
    [SerializeField] Rigidbody2D enemyRigidBody;
    [SerializeField] float enemySpeed;
    [SerializeField] float waitingTime = 3f;
    float timerCount;

    float LeftXSpawnPosition = -11f;
    float RightXSpawnPosition = 11f;

    float positionY;
    //float randomSpawnPositionYMin = -2.5f;
    //float randomSpawnPositionYMax = 3f;

    enum BabyBearState
    {
        WAIT_LEFT,
        WAIT_RIGHT,
        GO_LEFT,
        GO_RIGHT,
        KILLED,
    }

    BabyBearState babyBearState;

    bool calledOnceInFunction = true;
    
	void Start () {
        enemySpeed = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Waves>().BabyBearSpeed;
        enemyTransform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        positionY = enemyTransform.position.y;
        if (enemyTransform.position.x < 11f)
        {
            babyBearState = BabyBearState.GO_RIGHT;
        }
        else
        {
            babyBearState = BabyBearState.GO_LEFT;
        }      
		
	}
	
	void Update () {
        switch (babyBearState)
        {
            case BabyBearState.WAIT_LEFT:
                WaitOutside(BabyBearState.GO_RIGHT);
                break;
            case BabyBearState.WAIT_RIGHT:
                WaitOutside(BabyBearState.GO_LEFT);
                break;
            case BabyBearState.GO_LEFT:
                GoLeft();
                break;
            case BabyBearState.GO_RIGHT:
                GoRight();
                break;
            case BabyBearState.KILLED:
                Killed();
                break;
        }
		
	}

    void GoLeft()
    {
        if (calledOnceInFunction)
        {
            enemyTransform.position = new Vector3(RightXSpawnPosition, positionY, 0);
            enemyRigidBody.velocity = new Vector2(-enemySpeed, 0);
            calledOnceInFunction = false;
        }

        if (enemyTransform.position.x <= -11f)
        {
            babyBearState = BabyBearState.WAIT_LEFT;
            calledOnceInFunction = true;
        }
    }

    void GoRight()
    {
        if (calledOnceInFunction)
        {
            enemyTransform.position = new Vector3(LeftXSpawnPosition, positionY, 0);
            enemyRigidBody.velocity = new Vector2(enemySpeed, 0);
            calledOnceInFunction = false;
        }

        if (enemyTransform.position.x >= 11f)
        {
            babyBearState = BabyBearState.WAIT_RIGHT;
            calledOnceInFunction = true;
        }
    }

    void Killed()
    {

    }

    void WaitOutside(BabyBearState state)
    {
        if (calledOnceInFunction)
        {
            timerCount = Time.timeSinceLevelLoad;
            calledOnceInFunction = false;
        }
        if (Time.timeSinceLevelLoad - timerCount >= 3f)
        {
            babyBearState = state;
            calledOnceInFunction = true;
        }
    }
}

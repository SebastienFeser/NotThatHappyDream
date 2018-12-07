using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDollHead : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemyRigidBody;
    [SerializeField] Transform enemyTransform;

    [SerializeField] float headSpeed;
    [SerializeField] float headDeceleration;

    float positionAtStart;
    float positionUp = 3.5f;

    bool calledOnceInFunction = true;

    enum HeadStates
    {
        SPEED_UP,
        SPEED_DOWN,
        DECELERATION,
        DESTROY,
    }

    HeadStates headStates;

    void Start()
    {
        positionAtStart = enemyTransform.position.y;

    }

    void Update()
    {

        

        switch (headStates)
        {
            case HeadStates.SPEED_UP:
                SpeedUp();
                break;
            case HeadStates.SPEED_DOWN:
                SpeedDown();
                break;
            case HeadStates.DECELERATION:
                headStates = HeadStates.SPEED_DOWN;
                break;
            case HeadStates.DESTROY:
                Destroy();
                break;
        }


    }
    void SpeedUp()
    {
        if (calledOnceInFunction)
        {
            enemyRigidBody.velocity = new Vector3(0, headSpeed, 0);
            calledOnceInFunction = false;
        }
        if (enemyTransform.position.y >= positionUp)
        {
            headStates = HeadStates.DECELERATION;
            calledOnceInFunction = true;
        }

    }

    void SpeedDown()
    {
        if (calledOnceInFunction)
        {
            enemyRigidBody.velocity = new Vector3(0, -headSpeed, 0);
            calledOnceInFunction = false;
        }
        if (enemyTransform.position.y <= positionAtStart)
        {
            headStates = HeadStates.DESTROY;
            calledOnceInFunction = true;
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}

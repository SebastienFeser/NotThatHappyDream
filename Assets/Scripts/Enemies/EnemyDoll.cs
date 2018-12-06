using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoll : MonoBehaviour {
    [SerializeField] Transform enemyTransform;
    [SerializeField] Transform playerTransform;
    [SerializeField] Collider2D enemyCollider;
    [SerializeField] Rigidbody2D enemyRigidBody;
    [SerializeField] float enemySpeed;

    [SerializeField] GameObject dollHead;
    Vector2 dollHeadStartPosition;

    enum DollStates
    {
        GO_LEFT,
        GO_RIGHT,
        LAUNCH_HEAD,
        KILLED,
    }

    DollStates dollStates;

    DollStates dollStateBackup;

    bool calledOnceInFunction = true;
    // Use this for initialization
    void Start () {
        dollStates = DollStates.GO_RIGHT;
	}
	
	// Update is called once per frame
	void Update () {

        switch (dollStates)
        {
            case DollStates.GO_LEFT:
                GoLeft();
                break;
            case DollStates.GO_RIGHT:
                GoRight();
                break;
            case DollStates.LAUNCH_HEAD:
                LaunchHead();
                break;
            case DollStates.KILLED:
                break;
        }

        if (enemyTransform.position.x - playerTransform.position.x <= 0.05f && enemyTransform.position.x - playerTransform.position.x >= -0.05f)
        {
            dollStates = DollStates.LAUNCH_HEAD;
        }
		
	}

    void GoRight()
    {
        if (calledOnceInFunction)
        {
            enemyRigidBody.velocity = new Vector2(enemySpeed, 0);
            calledOnceInFunction = false;
        }

        if (enemyTransform.position.x >= 8f)
        {
            dollStates = DollStates.GO_LEFT;
            calledOnceInFunction = true;
        }
    }

    void GoLeft()
    {
        if (calledOnceInFunction)
        {
            enemyRigidBody.velocity = new Vector2(-enemySpeed, 0);
            calledOnceInFunction = false;
        }

        if (enemyTransform.position.x <= -8f)
        {
            dollStates = DollStates.GO_RIGHT;
            calledOnceInFunction = true;
        }
    }

    void LaunchHead()
    {
        if (calledOnceInFunction)
        {
            enemyRigidBody.velocity = new Vector2(0, 0);
            dollHeadStartPosition = enemyTransform.position;
            Instantiate(dollHead, dollHeadStartPosition, Quaternion.identity);
            calledOnceInFunction = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoll : MonoBehaviour {
    [SerializeField] Transform enemyTransform;
    [SerializeField] Transform playerTransform;
    [SerializeField] Collider2D enemyCollider;
    [SerializeField] Rigidbody2D enemyRigidBody;
    [SerializeField] float enemySpeed;

    enum DollStates
    {
        GO_LEFT,
        GO_RIGHT,
        LAUNCH_HEAD,
        KILLED,
    }

    DollStates dollStates;

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
                break;
            case DollStates.KILLED:
                break;
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
}

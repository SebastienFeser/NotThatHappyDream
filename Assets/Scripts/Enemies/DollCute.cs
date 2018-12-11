using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollCute : MonoBehaviour {
    [SerializeField] Transform enemyTransform;
    [SerializeField] Collider2D enemyCollider;
    [SerializeField] Rigidbody2D enemyRigidBody;
    [SerializeField] float enemySpeed;
    

    enum DollStates
    {
        GO_LEFT,
        GO_RIGHT,
        KILLED,
    }

    DollStates dollStates;

    DollStates dollStateBackup;

    bool calledOnceInFunction = true;
    bool calledOnceInFunctionHead = true;

    bool checkPlayerPosition = true;

    // Use this for initialization
    void Start()
    {
        enemySpeed = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Wave0>().DollSpeed;
        if (enemyTransform.position.x < 11f)
        {
            dollStates = DollStates.GO_RIGHT;
        }
        else
        {
            dollStates = DollStates.GO_LEFT;
        }
    }

    // Update is called once per frame
    void Update()
    {

        switch (dollStates)
        {
            case DollStates.GO_LEFT:
                GoLeft();
                break;
            case DollStates.GO_RIGHT:
                GoRight();
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

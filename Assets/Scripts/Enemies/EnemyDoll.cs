using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoll : MonoBehaviour {
    [SerializeField] Transform enemyTransform;
    [SerializeField] GameObject playerGameObject;
    [SerializeField] Collider2D enemyCollider;
    [SerializeField] Rigidbody2D enemyRigidBody;
    [SerializeField] float enemySpeed;
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite launchSprite;
    [SerializeField] SpriteRenderer spriteRenderer;

    GameObject dollHeadInstantiated;

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
    bool calledOnceInFunctionHead = true;

    bool checkPlayerPosition = true;

    // Use this for initialization
    void Start () {
        spriteRenderer.sprite = normalSprite;
        enemySpeed = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Waves>().DollSpeed;
        if (enemyTransform.position.x < 11f)
        {
            dollStates = DollStates.GO_RIGHT;
        }
        else
        {
            dollStates = DollStates.GO_LEFT;
        }
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
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

        if (checkPlayerPosition 
            && enemyTransform.position.x - playerGameObject.transform.position.x <= 0.1f 
            && enemyTransform.position.x - playerGameObject.transform.position.x >= -0.1f)
        {

            dollStateBackup = dollStates;
            dollStates = DollStates.LAUNCH_HEAD;
            Debug.Log(dollStateBackup);
            checkPlayerPosition = false;
            calledOnceInFunction = true;
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
        if (calledOnceInFunctionHead)
        {
            spriteRenderer.sprite = launchSprite;
            enemyRigidBody.velocity = new Vector2(0, 0);
            dollHeadStartPosition = enemyTransform.position;
            dollHeadInstantiated = Instantiate(dollHead, dollHeadStartPosition, Quaternion.identity);
            calledOnceInFunctionHead = false;
        }

        if (dollHeadInstantiated == null)
        {
            spriteRenderer.sprite = normalSprite;
            dollStates = dollStateBackup;
            checkPlayerPosition = true;
            calledOnceInFunctionHead = true;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class NewAI : MonoBehaviour
{
    private Queue<GameObject> newQueue = new Queue<GameObject>();
    private GameObject[] allBlocks;
    public Rigidbody2D rb;
    public GameObject redBasket, blueBasket;
    public Transform positionForHolding;
    //public Button button;
    
    //int count = -1;
    void Update()
    {
        Debug.Log(newQueue.Count);

        newQueue = queueFunc();
        GoToFirstBlock();
    }

    public Queue<GameObject> queueFunc()
    {
        /*if(count != allBlocks.Length)
        {
            allBlocks = GameObject.FindGameObjectsWithTag("clone");
            count = allBlocks.Length;
        }*/

        //button.onClick.AddListener( () => FindClones() );

        //FIX IT - CHECKING ALL THE TIME
        allBlocks = GameObject.FindGameObjectsWithTag("clone");
        newQueue = new Queue<GameObject>();

        foreach (GameObject go in allBlocks)
        {
            Debug.Log("Now in Queue: " + newQueue.Count);
            newQueue.Enqueue(go);
        }
        return newQueue;
    }

    /*public void FindClones()
    {
        allBlocks = GameObject.FindGameObjectsWithTag("clone");
    }*/


    public void GoToFirstBlock()
    {
        if (newQueue.Count >= 1)
        {
            GameObject target = newQueue.Dequeue();
            target.layer = 9; //Can be fixed, but not too important

            if (positionForHolding.childCount <= 0)
            {
                rb.MovePosition(new Vector2(transform.position.x, 0) + new Vector2(target.transform.position.x - transform.position.x, 0) * Time.fixedDeltaTime);
            }

            if (rb.IsTouching(target.gameObject.GetComponent<Collider2D>()))
            {
                target.transform.parent = positionForHolding;
                target.transform.position = positionForHolding.position;
                goToStash(target);
            }
        }
    }

    void goToStash(GameObject targetObj)
    {
        if (targetObj.name == "RedBlock(Clone)")
        {
            rb.MovePosition(new Vector2(transform.position.x, 0) + (new Vector2(redBasket.transform.position.x, 0) * 1f * Time.fixedDeltaTime));
            if (rb.IsTouching(redBasket.gameObject.GetComponent<Collider2D>()))
            {
                Debug.Log("Spremam " + targetObj.name);
                Destroy(targetObj);
                //count--;
            }
        }
        else if (targetObj.name == "BlueBlock(Clone)")
        {
            rb.MovePosition(new Vector2(transform.position.x, 0) + (new Vector2(blueBasket.transform.position.x, 0) * 1f * Time.fixedDeltaTime));
            if (rb.IsTouching(blueBasket.gameObject.GetComponent<Collider2D>()))
            {
                Debug.Log("Spremam " + targetObj.name);
                Destroy(targetObj);
                //count--;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    //Blocks
    public GameObject redBlock, blueBlock;
    private GameObject red, blue;

    public void Spawn()
    {
        Vector3 redPosition = new Vector3(Random.Range(-4, 1), Random.Range(4, 7), 0);
        Vector3 bluePosition = new Vector3(Random.Range(1, 4), Random.Range(4, 7), 0);

        red = (GameObject)Instantiate(redBlock, redPosition, Quaternion.identity);
        blue = (GameObject)Instantiate(blueBlock, bluePosition, Quaternion.identity);
    }

    /*public void Update()
    {
        Destroy(red, 2f);
        Destroy(blue, 2f);
    }*/
}

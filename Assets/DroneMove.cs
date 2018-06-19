using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMove : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(move());
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    // every 2 seconds perform the print()
    private IEnumerator move()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            iTween.MoveBy(gameObject, iTween.Hash(
 "x", 4,
 "time", 1.2f
));
            yield return new WaitForSeconds(1.5f);
            iTween.MoveBy(gameObject, iTween.Hash(
        "z", 4,
        "time", 1.2f
    ));
        }
    }
}

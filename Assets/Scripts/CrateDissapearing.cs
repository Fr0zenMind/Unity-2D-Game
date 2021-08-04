using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDissapearing : MonoBehaviour
{
    Vector2 _startPosition;
    Vector2 _newPosition;
    public float timeWhenAllowedNextShoot = 0f;
    public float timeBetweenShooting = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(true);
        _startPosition = GetComponent<Rigidbody2D>().position;
        
    }

    // Update is called once per frame
    void Update()
    {
        _newPosition = GetComponent<Rigidbody2D>().position;
        if (_startPosition != _newPosition)
            goToStartPosition();
        //checkedIfChangedPosition();
        

    }

    private void goToStartPosition()
    {
        if (timeWhenAllowedNextShoot <= Time.time)
        {
            GetComponent<Rigidbody2D>().position = _startPosition;
            timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
        }
    }
    /*
IEnumerator ExampleCoroutine()
{
   //Print the time of when the function is first called.
   //Debug.Log("Started Coroutine at timestamp : " + Time.time);

   //yield on a new YieldInstruction that waits for 5 seconds.
   //gameObject.SetActive(true);

   gameObject.GetComponent<Rigidbody2D>().SetRotation(180f);


   yield return new WaitForSeconds(2);

   gameObject.GetComponent<Rigidbody2D>().SetRotation(180f);

   //gameObject.SetActive(false);

   //After we have waited 5 seconds print the time again.
   //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
}

*/



    /*
    void checkIfDissapearing()
    {
        
        if (timeWhenAllowedNextShoot <= Time.time)
        {
            _ = StartCoroutine(ExampleCoroutine());
            timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
        }
        

        
    }
    
    */


}

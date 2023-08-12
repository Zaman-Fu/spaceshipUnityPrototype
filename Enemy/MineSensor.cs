using ShipGame.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSensor : MonoBehaviour
{
    [SerializeField]
    GameObject mineObject;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PrimeTimer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("It's gonna blow!");
            mineObject.GetComponent<Mine>().Detonate();
        }
    }
    private IEnumerator PrimeTimer()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.GetComponent<Collider2D>().enabled = true;

    }

}

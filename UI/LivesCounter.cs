using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    [SerializeField]
    GameObject lifeIcon;
    // Start is called before the first frame update
   
    public void SetLives(int lives)
    {
        Debug.Log("Updating lives");
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for(int i = 0; i < lives; i++)
        {
            Instantiate(lifeIcon,transform);
        }
    }
}

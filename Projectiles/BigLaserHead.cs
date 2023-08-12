using ShipGame.Enemies;
using ShipGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLaserHead : MonoBehaviour, Reflectable
{
    int damage = 10;
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    GameObject laserBeam;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FireSequence");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool HurtsPlayer()
    {
        return true;
    }

    public void Reflect()
    {
        throw new System.NotImplementedException("This projectile cannot be reflected");
    }
    private void FireLaserBeam()
    {
        Instantiate(laserBeam, gameObject.transform);
    }

    IEnumerator FireSequence()
    {
        yield return new WaitForSeconds(3);
        FireLaserBeam();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!");
        
        
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerShip>().TakeDamage(damage);
                
            }
            

        

    }
}

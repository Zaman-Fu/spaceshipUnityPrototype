using ShipGame.Enemies;
using ShipGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingFlare : MonoBehaviour, Reflectable
{

    // Start is called before the first frame update
    [SerializeField]
    Color enemyColor;
    [SerializeField]
    Color playerColor;
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    float speed = 15;
    [SerializeField]
    GameObject impactEffect;

    int damage = 5;

    [SerializeField] //Helpful for prefab setting
    bool isReflected = false;
    Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        if ((transform.position - origin).magnitude > 80)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!");
        if (isReflected)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                ImpactEffect();
                //This projectile does not die on enemy collision.
                
            }

        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerShip>().TakeDamage(damage);
                Die();
            }
            if (collision.gameObject.CompareTag("PlayerShield"))
            {
                Reflect();
                FindObjectOfType<PlayerShip>().AddEnergy(2);//For every successful reflect. TODO: avoid using find. Use reference to the shield to reach the PlayerShip object.
            }

        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public bool IsReflected()
    {
        return !isReflected;
    }

    public bool HurtsPlayer()
    {
        return IsReflected();
    }


    //This projectile is player specific, and cannot be reflected by anyone
    public void Reflect()
    {
        throw new System.NotImplementedException();
    }

    protected void ImpactEffect()
    {
        Instantiate(impactEffect,transform.position,transform.rotation);
    }


}

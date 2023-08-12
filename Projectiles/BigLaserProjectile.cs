using ShipGame;
using ShipGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Projectiles
{
    public class BigLaserProjectile : MonoBehaviour, Reflectable
    {

        int damage = 10;

        public bool HurtsPlayer()
        {
            return true;
        }

        public void Reflect()
        {
            throw new System.NotImplementedException("Not reflectable");
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

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
}


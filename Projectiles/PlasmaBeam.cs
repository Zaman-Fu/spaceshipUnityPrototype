using ShipGame.Enemies;
using ShipGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipGame.Projectiles
{
    public class PlasmaBeam : MonoBehaviour,Reflectable
    {
        // Start is called before the first frame update
        [SerializeField]
        Color enemyColor;
        [SerializeField]
        Color playerColor;
        [SerializeField]
        SpriteRenderer sprite;
        [SerializeField]
        float speed = 5;
        [SerializeField]
        int damage = 1;
        [SerializeField]
        GameObject impactEffect;

        [SerializeField] //Helpful for prefab setting
        bool isReflected = false;
        Vector3 origin;
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

        public bool IsReflected()
        {
            return isReflected;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void Die()
        {
            Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Collision!");
            if(isReflected)
            {
                if (collision.gameObject.CompareTag("Enemy"))
                {
                    collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                    ImpactEffect();
                    Die();
                }
              
            }
            else
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    collision.gameObject.GetComponent<PlayerShip>().TakeDamage(damage);
                    ImpactEffect();
                    Die();
                }
                if (collision.gameObject.CompareTag("PlayerShield"))
                {
                    Reflect();
                    FindObjectOfType<PlayerShip>().AddEnergy(5);//For every successful reflect. TODO: avoid using find. Use reference to the shield to reach the PlayerShip object.
                }

            }
            
        }

        public void SwitchPolarity()
        {
            isReflected = true;
            sprite.color=playerColor;
        }

        public void ReverseDirection()
        {
            //Simple 180 degree rotation
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z+180);
        }

        public void SetSpeed(int value)
        {
            speed=value;
        }

        public bool HurtsPlayer()
        {
            return !isReflected;
        }

        //Do something if it's reflected
        public void Reflect()
        {
            SwitchPolarity();
            ReverseDirection();
        }

        protected void ImpactEffect()
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShipGame.Weapons;
using ShipGame.Management;
using ShipGame.Enemies.Movement;
using System.Linq;

namespace ShipGame.Enemies
{
    public abstract class Enemy : MonoBehaviour,Damageable
    {
        protected Transform target;
        protected MovementPattern movement;
        [SerializeField]
        protected int pointValue;

        

        //protected bool readyToFire=true; cooldown relegated to weapons themselves instead.
        //Every weapon must have a cooldown for this to work. Think about refactoring into map.
        [SerializeField]
        protected List<Weapon> weapons= new List<Weapon>();
        protected float cooldown;

        

        [SerializeField]
        protected int health;

        [SerializeField]
        protected GameObject explosionObject;

       

        

        protected Rigidbody2D rb;

        protected bool active=false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        protected virtual void Initialize()
        {
            rb = GetComponent<Rigidbody2D>();
            movement = GetComponent<MovementPattern>();
        }

        protected abstract void Move();


        protected virtual void Die()
        {
            Instantiate(explosionObject,transform.position,Quaternion.identity);
            Destroy(gameObject);

        }
        protected virtual void Shoot()
        {
            weapons.ElementAt(0).Shoot();
        }
        public virtual void Activate()
        {
            active = true;
        }

       public  void TakeDamage(int damage)
        {
            Debug.Log("Enemy Took Damage");
            health -=damage;
            if(health <= 0)
            {
                PointManager.AwardPoints(pointValue);
                Die();
            }
            
        }
        
        public virtual bool IsActivated()
        {
            return active;
        }

        public Transform GetTarget()
        {
            return target;
        }

        /* this functionality moved  to the weapon class.
         * protected IEnumerator WeaponCooldown()
         {
             yield return new WaitForSeconds(cooldown);
             readyToFire = true;
         }*/
    }
}


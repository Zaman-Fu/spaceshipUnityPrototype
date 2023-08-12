using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Enemies

{
    /// <summary>
    /// This is technically a projectile, but due to it being worth points and having health it shall be classified as an enemy, just like the mine.
    /// </summary>
    public class SeekerMissile : Enemy
    {
        bool isLocked=false;
        
        //Todo: make it actually track the enemy continuously
        protected override void Move()
        {
            //take two seconds to aquire enemy and move at low speed

            //After enemy is aquired continuously seek him out

                    /*var direction = (GetTarget().position - transform.position).normalized;
                    transform.up = direction;*/
                    movement.Move();                
            
        }

        private void Awake()
        {
            Initialize();
        }
        // Start is called before the first frame update
        void Start()
        {
            
            StartCoroutine("HomeOnTarget");
        }

        // Update is called once per frame
        void Update()
        {
            movement.Move();
        }

        protected override void Initialize()
        {
            base.Initialize();
            movement.SetSpeed(2);
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Damageable>().TakeDamage(1);
                Die();
            }
        }

        IEnumerator HomeOnTarget()
        {
           yield return new WaitForSeconds(3.0f);
            isLocked = true;
            try
            {
                var direction = (GetTarget().position - transform.position).normalized;
                transform.up = direction;
                movement.SetSpeed(10);
                movement.Move();
            }
            catch (MissingReferenceException e)
            {
                Debug.LogWarning(e.ToString());
            }
        }
    }
}


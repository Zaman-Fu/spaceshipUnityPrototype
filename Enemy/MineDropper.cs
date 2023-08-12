using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipGame.Enemies
{
    public class MineDropper : Enemy
    {
        

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
            
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            if (Vector2.Distance(Vector2.zero, transform.position) > 35)
            {
                Die();
            }
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("Activating mine dropper");
            StartCoroutine("MineDrop");
        }

        //Drop
        protected override void Move()
        {
            movement.Move();
        }

        private IEnumerator MineDrop()
        {
            float waitTime = Random.Range(1.0f, 7.0f);
            yield return new WaitForSeconds(waitTime);
            Shoot();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



namespace ShipGame.Enemies

{
    public class Mine : Enemy
    {
        protected override void Move()
        {
            //Mine remains stationary
        }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("PrimeTimer");
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Detonate()
        {
            StartCoroutine("DetonationCountdown");
        }

        private IEnumerator PrimeTimer()
        {
            yield return new WaitForSeconds(1.0f);
            Activate();

        }

        private IEnumerator DetonationCountdown()
        {
            //TODO: Fluctuate the color of the mine before explosion
            Debug.Log("detonation countdown began");
            yield return new WaitForSeconds(2.0f);

            Die();
        }

        protected override void Die()
        {
            weapons.ElementAt(0).Shoot();
            base.Die();
        }
    }
}


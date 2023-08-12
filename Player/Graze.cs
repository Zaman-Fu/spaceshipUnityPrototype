using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace ShipGame.Player
{
    public class Graze : MonoBehaviour
    {

        [SerializeField]
        PlayerShip ship;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /*
        public void HasGrazed()
        {
            ship.AddEnergy(1);
        }*/




        //here, detect collision with projectiles, fill resource a bit for every individual collision

        private void OnTriggerEnter2D(Collider2D collision)
        {

            Debug.Log("Graze Detected");
            if(collision.gameObject.GetComponent<Reflectable>() != null)
            {
                if(collision.gameObject.GetComponent<Reflectable>().HurtsPlayer())
                {
                    ship.Grazed();
                }
            }
           
        }
    }


}

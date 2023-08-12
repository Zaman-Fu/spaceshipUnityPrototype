using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Player
{
    public class PlayerShield : MonoBehaviour
    {
        [SerializeField]
        float cooldown;
        [SerializeField]
        GameObject shield;
        AudioSource shieldAudioSource;

        bool readyToFire=true;
        // Start is called before the first frame update
       
        void Start()
        {
           readyToFire = true;
           shieldAudioSource=GetComponent<AudioSource>();
           shield.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Activates the shield instantly, then
        /// </summary>
        public void Activate(Vector2 direction)
        {
            Debug.Log("Shield ready to fire:" + readyToFire);
            if (!readyToFire)
                return;

            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            shield.SetActive(true);
            shieldAudioSource.Play();
            readyToFire = false;
            StartCoroutine("ShieldCooldown");
        }

        IEnumerator ShieldCooldown()
        {
            yield return new WaitForSeconds(0.5f);
            shield.SetActive(false);
            yield return new WaitForSeconds(1f);
            readyToFire = true;
            Debug.Log("Ready to shield");

        }
    }

}

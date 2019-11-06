using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public int defaultBulletDamage = 25;
    public float defaultBulletTime = 1f;
    public float range = 100f;
    public int bulletDamage;
   

    public ParticleSystem muzzleflashL1;
    public ParticleSystem muzzleflashR1;
 
    public Light weaponLight1;

    public GameObject shootPointLeft;
    public GameObject shootPointRight;

    int shootableMask;
    float timer;
    public float bulletTime;
    float effectsDisplayTime = 0.2f;

    AudioSource lvl1Gunshot;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        bulletDamage = defaultBulletDamage;
        bulletTime = defaultBulletTime;
        AudioSource[] audioClips = GetComponents<AudioSource>();    //due to there being multiple audioSources they are stored in an array.
        lvl1Gunshot = audioClips[0];


    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer >= bulletTime)
        {
            ShootGun();


        }
        if (timer >= bulletTime * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }
    }

    void ShootGun()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPointLeft.transform.position, shootPointLeft.transform.forward, out hit, range))
        {
            timer = 0f;
            lvl1Gunshot.Play();

            muzzleflashL1.Play();
            muzzleflashR1.Play();
            weaponLight1.enabled = true;
           
            ShakerController target = hit.transform.GetComponent<ShakerController>();

            if (target != null)
            {
                target.TakeDamage(bulletDamage);
            }
        }
    }
    void DisableEffects()
    {
        weaponLight1.enabled = false;
    }
}

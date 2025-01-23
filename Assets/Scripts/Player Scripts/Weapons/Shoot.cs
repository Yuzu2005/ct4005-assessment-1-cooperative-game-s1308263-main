using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Shoot : MonoBehaviour {
    
    [SerializeField] private GameObject bullet, RPGBullet, shotgunBullet;
    [SerializeField] private GameObject grenade, grenDamTrigger;
    [SerializeField] private GameObject ExploBar;
    [SerializeField] private GameObject EnemyShoot, EnemyMelee;
    [SerializeField] private GameObject shotgunSpawn1, shotgunSpawn2, shotgunSpawn3, shotgunSpawn4, shotgunSpawn5, shotgunSpawn6, shotgunSpawn7, shotgunSpawn8, shotgunSpawn9;
    [SerializeField] private GameObject playerModel, playerObject;
    [SerializeField] private GameObject grenTextObj, RPGTextObj;
    [SerializeField] private TMP_Text grenText, rPGText;

    public GameObject projectileSpawn;

    [SerializeField] private ParticleSystem flames;

    [Space(10)]


    [Space(10)]
    [SerializeField] private float shootVolume = 1.0f;

    [Space(10)]
    [SerializeField] private float fireRate = 0.1f;
    private float shotgunRate = 0.3f;
    private float bulletDeathTime = 0.6f;
    private float shotgunDeathTime = 0.2f;

    private float grenTimer = 5f;

    [Space(10)]
    private bool hasThrown, canThrow = true, isFlame;
    public bool isShooting, isShotgun, isRPG, hasFlamePickup, hasShotgunPickup, hasRPGPickup, isGrenade;

    public int GrenAmount = 3, RPGAmmo = 5;


    public AudioClip flameClip;
    public AudioClip shootClip;
    public AudioClip shotgunClip;
    public AudioClip RPGClip;
    public AudioClip grenPinClip;
    public AudioSource shootSource;

    private void Update() {
        grenText.SetText("Grenades: " + GrenAmount);
        grenTextObj.transform.rotation = Quaternion.Euler(0.0f, 0.0f, RPGTextObj.transform.rotation.z * -1.0f);
        if (GrenAmount <= 0) {
            grenTextObj.SetActive(false);
        }
        else {
            grenTextObj.SetActive(true);
        }
        if (hasRPGPickup == true) {
            RPGTextObj.SetActive(true);
            RPGTextObj.transform.rotation = Quaternion.Euler(0.0f, 0.0f, RPGTextObj.transform.rotation.z * -1.0f);
            rPGText.SetText("RPG Ammo: " + RPGAmmo);
            if (RPGAmmo == 0) {
                hasRPGPickup = false;
                isShooting = true;
                RPGTextObj.SetActive(false);
            }
        }
        if (hasThrown == true) {
            grenTimer -= 1 * Time.deltaTime;
            canThrow = false;
            if (grenTimer <= 0) {
                canThrow = true;
                grenTimer = 5f;
                hasThrown = false;
            }
        }
    }

    //Shoot input
    public void OnTriggerPull(InputAction.CallbackContext shoot) {
        switch (shoot.phase) {
            case InputActionPhase.Performed:
            StopAllCoroutines();
            isShooting = false;
            isShotgun = false;
            FlamethrowerStop();
            if (isFlame == true) {
                shootSource.Stop();
                isFlame = false;
            }
            break;
            case InputActionPhase.Canceled:
            if (hasFlamePickup == true) {
                isShooting = false;
                FlamethrowerStart();
                StopCoroutine("Autofire");

            }
            else if (hasRPGPickup == true) {
                isRPG = true;
                isShooting = false;
                StopCoroutine("Autofire");
                RPGShoot();
            }
            //Stop RPG and flamethrower being picked up at the same time
            else if (hasShotgunPickup == true && hasFlamePickup == false && hasRPGPickup == false) {
                isShotgun = true;
                if (FindObjectOfType<PlayerHealthScript>().isAlive == true) {
                    StopCoroutine("AutoFire");
                    StartCoroutine("AutoShotgun");
                }
            }
            else {
                isShooting = true;
                if(FindObjectOfType<PlayerHealthScript>().isAlive == true) {
                    StartCoroutine("AutoFire");
                }
                else if (FindObjectOfType<PlayerHealthScript>().isAlive == false) {
                    StopAllCoroutines();
                }
            }
            break;
        }
    }

    //Grenade throw input
    public void GrenadeThrow(InputAction.CallbackContext grenThrow) {
        if (grenThrow.performed) {
            if (canThrow == true && GrenAmount >= 0) {
                hasThrown = true;
                TryGetComponent<PlayerMovement>(out PlayerMovement move);
                if (move.isMoving == true) {
                    playerModel.GetComponent<PlayerAnimations>().GrenadeThrowRun();
                }
                else {
                    playerModel.GetComponent<PlayerAnimations>().GrenadeThrowIdle();
                }
                GrenAmount--;
                var cloneGrenade = Instantiate(grenade, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
                shootSource.PlayOneShot(grenPinClip);
            }
        }
        else if (GrenAmount <= 0) {
            Debug.Log("GrenAmount = " + GrenAmount);
            canThrow = false;
            hasThrown = false;
        }
    }


    //Bullet Auto-fire
    public IEnumerator AutoFire() {
        if (isShooting == true) {
            var cloneBullet = Instantiate(bullet, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
            shootSource.PlayOneShot(shootClip);
            shootSource.volume = shootVolume;
            shootSource.pitch = Random.Range(0.5f, 1f);
            Destroy(cloneBullet, bulletDeathTime);
            yield return new WaitForSeconds(fireRate);
            StartCoroutine("AutoFire");
        }
    }

    //Shotgun Auto-fire
    IEnumerator AutoShotgun() {
        if (isShotgun == true) {
            var cloneShotBullet1 = Instantiate(shotgunBullet, shotgunSpawn1.transform.position, shotgunSpawn1.transform.rotation);
            var cloneShotBullet2 = Instantiate(shotgunBullet, shotgunSpawn2.transform.position, shotgunSpawn2.transform.rotation);
            var cloneShotBullet3 = Instantiate(shotgunBullet, shotgunSpawn3.transform.position, shotgunSpawn3.transform.rotation);
            var cloneShotBullet4 = Instantiate(shotgunBullet, shotgunSpawn4.transform.position, shotgunSpawn4.transform.rotation);
            var cloneShotBullet5 = Instantiate(shotgunBullet, shotgunSpawn5.transform.position, shotgunSpawn5.transform.rotation);
            var cloneShotBullet6 = Instantiate(shotgunBullet, shotgunSpawn6.transform.position, shotgunSpawn6.transform.rotation);
            var cloneShotBullet7 = Instantiate(shotgunBullet, shotgunSpawn7.transform.position, shotgunSpawn7.transform.rotation);
            var cloneShotBullet8 = Instantiate(shotgunBullet, shotgunSpawn8.transform.position, shotgunSpawn8.transform.rotation);
            var cloneShotBullet9 = Instantiate(shotgunBullet, shotgunSpawn9.transform.position, shotgunSpawn9.transform.rotation);
            shootSource.PlayOneShot(shotgunClip);
            shootSource.volume = shootVolume;
            shootSource.pitch = Random.Range(0.7f, 1f);
            Destroy(cloneShotBullet1, shotgunDeathTime);
            Destroy(cloneShotBullet2, shotgunDeathTime);
            Destroy(cloneShotBullet3, shotgunDeathTime);
            Destroy(cloneShotBullet4, shotgunDeathTime);
            Destroy(cloneShotBullet5, shotgunDeathTime);
            Destroy(cloneShotBullet6, shotgunDeathTime);
            Destroy(cloneShotBullet7, shotgunDeathTime);
            Destroy(cloneShotBullet8, shotgunDeathTime);
            Destroy(cloneShotBullet9, shotgunDeathTime);
            yield return new WaitForSeconds(shotgunRate);
            StartCoroutine("AutoShotgun");
        }
    }

    //Starts flamethrower
    private void FlamethrowerStart(){
        TryGetComponent<FlamethrowerFuel>(out FlamethrowerFuel gasOn);
        if (gasOn.fuel >= 0) {
            isFlame = true;
            flames.Play();
            shootSource.PlayOneShot(flameClip);
            gasOn.isActive = true;
            gasOn.FuelConsume();
        }
    }

    //Stops flamethrower
    public void FlamethrowerStop() {
        flames.Stop();
        if (isFlame == true) {
            shootSource.Stop();
        }
        TryGetComponent<FlamethrowerFuel>(out FlamethrowerFuel gasOff);
        gasOff.isActive = false;
        gasOff.fuelTextObject.SetActive(false);
    }

    //shoot RPG
    private void RPGShoot() {
        if (RPGAmmo > 0) {
            RPGAmmo--;
            var cloneRPG = Instantiate(RPGBullet, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
            shootSource.PlayOneShot(RPGClip);
            shootSource.volume = shootVolume;
            shootSource.pitch = Random.Range(0.5f, 1f);
        }
    }

    //Adds grenade
    public void AddGrenade()
    {
        if (GrenAmount < 3)
        {
            GrenAmount++;
            canThrow = true;
        }
    }
}

//Script by Jacob
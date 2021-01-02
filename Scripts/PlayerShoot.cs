using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    Animation pistolanim;
    Animation uzianim;
    Animation shotgunanim;
    Animation shotgun2anim;
    Animation m4a1anim;
    Animation ak47anim;
    Animation deagleanim;
    Animation pistol2anim;
    Animation rifleanim;


    public int ammo;
    GameObject gunFront;
   
    public bool shot = false;
   public GameObject Player;

    public GameObject pistol;
    public GameObject uzi;
    public  GameObject shotgun;
    public GameObject shotgun2;
    public GameObject pistol2;
    public GameObject ak47;
    public GameObject m4a1;
    public GameObject deagle;
    public GameObject rifle;
 
    AudioSource gunSound;
    public ParticleSystem muzzle;
    public ParticleSystem kovan;
   
    private static PlayerShoot playerShoot;
    public static PlayerShoot Playershoot
    {
        get
        {
            if (playerShoot == null)
            {
                playerShoot = GameObject.FindObjectOfType<PlayerShoot>();
            }
            return playerShoot;
        }
    }


    private RaycastHit hit;
    private Ray ray;


    // Start is called before the first frame update
    void Start()
    {
        
        ammo = 1;
        gunFront = GameObject.FindGameObjectWithTag("gunfront");
        Player = gameObject;
        gunSound = GameObject.FindGameObjectWithTag("GunSound").GetComponent<AudioSource>();

        pistolanim = pistol.GetComponent<Animation>();
        uzianim = uzi.GetComponent<Animation>();
        shotgunanim = shotgun.GetComponent<Animation>();
        shotgun2anim = shotgun2.GetComponent<Animation>();
        m4a1anim = m4a1.GetComponent<Animation>();
        ak47anim = ak47.GetComponent<Animation>();
        deagleanim = deagle.GetComponent<Animation>();
        pistol2anim = pistol2.GetComponent<Animation>();
        rifleanim = rifle.GetComponent<Animation>();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerShootButton()
    {


        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "enemy")
            {
                Npc enemy = hit.collider.gameObject.GetComponent<Npc>();
                enemy.TakeDamage();
            }
            if(hit.collider.gameObject.tag == "GoldPrize")
            {
                GoldCounter gem = hit.collider.gameObject.GetComponent<GoldCounter>();
                gem.Money();
            }
            if (hit.collider.gameObject.tag == "ManaPrize")
            {
                ManaPrize mana = hit.collider.gameObject.GetComponent<ManaPrize>();
                mana.Mana();
            }
            if (hit.collider.gameObject.tag == "HealthPrize")
            {
                HealthPrize heal = hit.collider.gameObject.GetComponent<HealthPrize>();
                heal.Heal();
            }
            if (hit.collider.gameObject.tag == "EnemyShield")
            {
                EnemyShield shield= hit.collider.gameObject.GetComponent<EnemyShield>();
                shield.HitShield();
                
            }
        }


        if (uzi.activeSelf)
        {
            camerashake.Camerashake.duration = 0.1f;
            camerashake.Camerashake.magnitude = 0.2f;
        }
        if (ak47.activeSelf)
        {
            camerashake.Camerashake.duration = 0.1f;
            camerashake.Camerashake.magnitude = 0.2f;
        }
        if (m4a1.activeSelf)
        {
            camerashake.Camerashake.duration = 0.1f;
            camerashake.Camerashake.magnitude = 0.2f;
        }
        if (shotgun.activeSelf)
        {
            camerashake.Camerashake.duration = 0.2f;
            camerashake.Camerashake.magnitude = 0.3f;

        }
        if (shotgun2.activeSelf)
        {
            camerashake.Camerashake.duration = 0.2f;
            camerashake.Camerashake.magnitude = 0.3f;

        }
        if (pistol.activeSelf)
        {
            camerashake.Camerashake.duration = 0.08f;
            camerashake.Camerashake.magnitude = 0.18f;

        }
        if (pistol2.activeSelf)
        {
            camerashake.Camerashake.duration = 0.08f;
            camerashake.Camerashake.magnitude = 0.18f;

        }
        if (deagle.activeSelf)
        {
            camerashake.Camerashake.duration = 0.08f;
            camerashake.Camerashake.magnitude = 0.18f;

        }

        camerashake.Camerashake.StartCoroutine(camerashake.Camerashake.shake());
        if (!shot)
        {
            kovan.Play();
            muzzle.Play();
            gunSound.Play();
            shot = true;
            //ammo--;
            GameObject bulletObject = Instantiate(bulletPrefab);

            /* bulletObject.transform.position = Main.transform.position + Main.transform.forward;
             bulletObject.transform.forward = Main.transform.forward;*/
            bulletObject.transform.position = gunFront.transform.position + gunFront.transform.forward;
            bulletObject.transform.forward = gunFront.transform.forward;
            if (pistol.activeInHierarchy)
            {
                StartCoroutine(Shoot(0.5f));
                pistolanim.Play("pistol_sekme");
            }
            if (pistol2.activeInHierarchy)
            {
                StartCoroutine(Shoot(0.5f));
                pistol2anim.Play("pistol2_sekme");
            }
            if (deagle.activeInHierarchy)
            {
                StartCoroutine(Shoot(0.5f));
                deagleanim.Play("deagle_sekme");
            }

            if (uzi.activeInHierarchy)
            {
                StartCoroutine(Shoot(0.2f));
                uzianim.Play("uzi_sekme");
            }
            if (ak47.activeInHierarchy)
            {
                StartCoroutine(Shoot(0.2f));
               ak47anim.Play("ak47_sekme");
            }
            if (m4a1.activeInHierarchy)
            {
                StartCoroutine(Shoot(0.2f));
                m4a1anim.Play("m4a1_sekme");
            }

            if (shotgun.activeInHierarchy)
            {
                StartCoroutine(Shoot(1f));
                shotgunanim.Play("shotgun_sekme");
            }
            if (shotgun2.activeInHierarchy)
            {
                StartCoroutine(Shoot(1f));
                shotgun2anim.Blend("shotgun2_sekme");
                shotgun2anim.Play("shotgun_pull");
            }
            IEnumerator Shoot(float time)
            {
                if (!shot)
                {

                }

                yield return new WaitForSeconds(time);
                shot = false;

                // Code to execute after the delay
            }
        }
    }
    IEnumerator EnemyShoot(float time)
    {
        if (!shot)
        {

        }

        yield return new WaitForSeconds(time);
        shot = false;

        // Code to execute after the delay
    }

}

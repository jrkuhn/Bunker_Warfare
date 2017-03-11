using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterController))]
public class PlayerControls : MonoBehaviour
{

    CharacterController pc;
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpSpeed = 10.0f;
    public bool isGrounded;
    Vector3 speed = Vector3.zero;
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float dist = 100f;          // The length of the ray from the camera into the scene.
    Ray ray;
    public AudioSource source;
    public AudioClip shootsound;
   

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Transform Enemy;
    private float fireRate = 0.5F;
    private float nextFire = 0.0F;



    void Start()
    {

        pc = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        //isGrounded = pc.isGrounded;

        //rotation
        Plane plane = new Plane(transform.up, transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out dist))
        {
            transform.LookAt(ray.GetPoint(dist));
        }


        //Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float slideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 speed = new Vector3(slideSpeed, 0, forwardSpeed);

        //move
        pc.Move(speed * Time.deltaTime);

        //shooting
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {

            source.PlayOneShot(shootsound);
            nextFire = Time.time + fireRate;
            Fire();

        }

    }


	void Fire()
    {
        
    // Create the Bullet from the Bullet Prefab
    var bullet = (GameObject)Instantiate(
        bulletPrefab,
        bulletSpawn.position,
        bulletSpawn.rotation);

    // Add velocity to the bullet
    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 12;

        
    // Destroy the bullet after 2 seconds
    Destroy(bullet, 2.5f);
    }

}
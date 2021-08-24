/*PlayerController.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10;
    public float jumpForce = 10;
    public float timeBeforeBehav = 0.5f;
    public float canBehav = 0f;
    public int maxHealth = 10;
    public int fireInput = 0;
    public int health { get { return currentHealth; } }
    int currentHealth;
    Animator animator;
    Rigidbody rgbody;
    public Camera mainCamera;

    public GameObject player;
    public GameObject bulletPrefab;

    public float timeInvincible = 2.0f;
    bool isInvincible; //true=무적
	float invincibleTimer; //남은 무적 시간

    void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            fireInput = 0;
            Vector3 firePos = transform.position + animator.transform.forward + new Vector3(0f, 0.5f, 0f);
            Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            for(int i=0; i<4; i++)
            {
                target.x += i;
                target.y += i;
                target.z += i;
                var bullet = Instantiate(bulletPrefab, target, Quaternion.identity).GetComponent<Bullet>();
                bullet.Fire(animator.transform.forward);
            }
            ChangeBullet(fireInput);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            fireInput = 1;
            Vector3 firePos = transform.position + animator.transform.forward + new Vector3(0f, 0.5f, 0f);
            Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            var bullet = Instantiate(bulletPrefab, target, Quaternion.identity).GetComponent<Bullet>();
            bullet.Fire(animator.transform.forward);
            ChangeBullet(fireInput);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rgbody = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        controllerPlayer();
        LookMouseCursor();
        Fire();
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0) //남은 무적 시간이 없으면
            {
                isInvincible = false; //무적 해지
            }

        }
    }
        public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if (currentHealth == 0)
        {
            animator.SetInteger("GunShot",1);
            //Destroy(this.gameObject);
            GameController.instance.GameOver();
        }
        else if (amount < 0)
           {
            animator.SetTrigger("Dive");
            if (isInvincible) return; //무적이면 리턴
            isInvincible = true;
            invincibleTimer = timeInvincible;
            }
    }
    public void ChangeBullet(int input)
    {
        if(GameController.instance.leftBullet<=0)
        {
            GameController.instance.GameOver();
        }
        if(input==0)
        {
            GameController.instance.leftBullet -= 4;
            GameController.instance.UpdateBullet();
        }
        else if(input==1)
        {
            GameController.instance.leftBullet--;
            GameController.instance.UpdateBullet();
        }
    }

    void controllerPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canBehav)
        {
            rgbody.AddForce(0, jumpForce, 0);
            canBehav = Time.time + timeBeforeBehav;
            animator.Play("Jump");
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("FourShot");
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.Play("SingleShot");
        }

        if (movement != Vector3.zero)
        {
            animator.Play("Run");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }

    public void LookMouseCursor()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult;
        if(Physics.Raycast(ray, out hitResult))
        {
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            animator.transform.forward = mouseDir;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        NPCCollision npc = collision.gameObject.GetComponent<NPCCollision>();
        if(npc!=null)
        {
            animator.Play("Dive");
        }
    }
}

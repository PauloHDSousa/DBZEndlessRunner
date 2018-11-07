using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 targetPos;
    private Vector2 startTouchPosition, endTouchPosition;

    public int health;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;
    public GameObject scoreManager;
    public GameObject spawner;
    public GameObject restartDisplay;
    AudioSource audioSource;
    Animator animator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (health <= 0) {
            spawner.SetActive(false);
            scoreManager.SetActive(false);
            restartDisplay.SetActive(true);
            Destroy(gameObject);
        }

        healthDisplay.text = health.ToString();
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if ((endTouchPosition.y < startTouchPosition.y) && transform.position.y > minY)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y - increment);
                MoveEffects();
            }
            if ((endTouchPosition.y > startTouchPosition.y) && transform.position.y < maxY)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y + increment);
                MoveEffects();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY) {
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
            MoveEffects();
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY) {
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
            MoveEffects();
        }
    }

    void MoveEffects()
    {
        camAnim.SetTrigger("shake");
        Instantiate(moveEffect, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(audioSource.clip);
        animator.SetTrigger("Teleport");
    }
}

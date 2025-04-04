using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator animator;

    [SerializeField] private float maxHp = 10f;
    [SerializeField] private float currentHp;
    [SerializeField] private Image hpBar;

    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiManager.PauseGameMenu();
        }
    }

    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = playerInput.normalized * moveSpeed;
        
        RotatePlayer(playerInput);
        IsRunning(playerInput);
    }

    void RotatePlayer(Vector2 playerInput)
    {
        if (playerInput.x < 0)
        {
            sp.flipX = true;
        }
        else if (playerInput.x > 0)
        {
            sp.flipX = false;
        }
    }

    void IsRunning(Vector2 playerInput)
    {
        if (playerInput != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        uiManager.GameOver();
    }

    protected void UpdateHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }

    public void Heal(float healValue)
    {
        if (currentHp < maxHp)
        {
            currentHp += healValue;
            currentHp = Mathf.Min(maxHp, currentHp);
            UpdateHpBar();
        }
    }
}

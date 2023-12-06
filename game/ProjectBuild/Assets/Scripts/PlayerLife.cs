using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public AudioClip deathSound; // Звук смерти
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Инициализация AudioSource
        audioSource = GetComponent<AudioSource>();
        if (deathSound != null)
        {
            audioSource.clip = deathSound;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Death();
        }
    }

    private void Death()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Static;

        anim.SetTrigger("death");

        // Воспроизведение звука смерти
        PlayDeathSound();

        // Вызываем метод RestartScene через 2 секунды после смерти
        Invoke("RestartScene", 2f);
    }

    private void PlayDeathSound()
    {
        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
    }

    private void RestartScene()
    {
        // Перезапускаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
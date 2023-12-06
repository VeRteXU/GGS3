using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int kiwis = 0;
    [SerializeField] private TextMeshProUGUI kiwisText;
    [SerializeField] private AudioSource audioSource; 
    [SerializeField] private AudioClip pickupClip; 

    private void Start()
    {
        if (audioSource == null)
        {
           
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("kiwi"))
        { 
            Destroy(collision.gameObject);
            kiwis++;
            kiwisText.text = "Kiwis: " + kiwis;
            PlayerPrefs.SetInt("Kiwis", kiwis);

            if (audioSource != null && pickupClip != null)
            {
                audioSource.PlayOneShot(pickupClip); 
            }
        }
    }
}
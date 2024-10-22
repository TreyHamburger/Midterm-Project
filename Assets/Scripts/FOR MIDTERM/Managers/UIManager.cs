using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera cutsceneCamera;

    [Header("UI Element")]
    public TMP_Text txtHealth;
    public GameObject gameOver;
    public GameObject crosshair1;
    public GameObject crosshair2;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    private void OnEnable()
    {
        playerHealth.OnHealthUpdated += OnHealthUpdated;
        playerHealth.OnDeath += OnDeath;
    }

    private void OnDestroy()
    {
        playerHealth.OnHealthUpdated -= OnHealthUpdated;
    }

    void OnHealthUpdated(float health)
    {
        txtHealth.text = "Health : " + Mathf.Floor(health).ToString();
    }

    void OnDeath()
    {
        gameOver.SetActive(true);
        player.gameObject.SetActive(false);
        SwitchToCutsceneCamera();
        
    }

    private void SwitchToCutsceneCamera()
    {
        cutsceneCamera.gameObject.SetActive(true);
        crosshair1.SetActive(false);
        crosshair2.SetActive(false);
    }
}

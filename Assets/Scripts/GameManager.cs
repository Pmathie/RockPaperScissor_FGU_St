using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject[] playerChoices;
    public GameObject[] enemyChoices;
    
    public float playerHealth;
    public float enemyHealth;
    private float startingHealth;
    private float enemyStartingHealth;

    public Image playerHealthBar;
    public Image enemyHealthBar;

    public float countDownTime;
    public TextMeshProUGUI countDownText;
    private bool canChoose = false;

    private AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingHealth = playerHealth;
        enemyStartingHealth = enemyHealth;
        audioManager = AudioManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPress(GameObject playerChoice)
    {
        if(canChoose == false)
        {
            audioManager.PlaySound("Error");
            return;

        }
        GameObject enemyChoice = enemyChoices[Random.Range(0, enemyChoices.Length)];
        foreach (GameObject a in playerChoices)
        {
            a.SetActive(false);
        }
        foreach (GameObject b in enemyChoices)
        {
            b.SetActive(false);
        }
        
        enemyChoice.SetActive(true);
        playerChoice.SetActive(true);
        audioManager.PlaySound(playerChoice.GetComponent<AudioSource>().name);


        Debug.Log("Du valgte: " + playerChoice.tag);
        Debug.Log("Din modstander valgte: " + enemyChoice.tag);

        if (playerChoice.CompareTag(enemyChoice.tag))
        {
            Debug.Log("Den er uafgjort!");
        }
        else if (playerChoice.CompareTag("Sten") && enemyChoice.CompareTag("Saks")|| 
                 playerChoice.CompareTag("Saks") && enemyChoice.CompareTag("Papir")||
                 playerChoice.CompareTag("Papir") && enemyChoice.CompareTag("Sten"))
        {
            Debug.Log("Du vandt!");
            UpdateHealth(0, 1);
        }
        else
        {
            Debug.Log("Du tabte!");
            UpdateHealth(1, 0);
        }
        canChoose = false;

    }
    public void UpdateHealth(float playerDamage, float enemyDamage)
    {
        if (playerDamage > 0)
        { 
            playerHealth = playerHealth - playerDamage;
            playerHealthBar.fillAmount = playerHealth / startingHealth;
            Debug.Log("Player Health:" + playerHealth);
        }
        if (enemyDamage > 0)
        {
            enemyHealth = enemyHealth - enemyDamage;
            enemyHealthBar.fillAmount = enemyHealth / enemyStartingHealth;
            Debug.Log("Enemy Health:" + enemyHealth);
        }

    }
    public void StartRoundButton()
    {
        
        StartCoroutine(CountDown());
    }
    private IEnumerator CountDown()
    {
        countDownText.text = "Vent til NU før du vælger!";
        yield return new WaitForSeconds(countDownTime);
        countDownText.text = "Sten";
        yield return new WaitForSeconds(countDownTime);
        countDownText.text = "Saks";
        yield return new WaitForSeconds(countDownTime);
        countDownText.text = "Papir";
        yield return new WaitForSeconds(countDownTime);
        countDownText.text = "NU!";
        canChoose = true;
    }
}

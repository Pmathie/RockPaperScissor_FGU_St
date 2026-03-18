using UnityEngine;
using UnityEngine.UI;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingHealth = playerHealth;
        enemyStartingHealth = enemyHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPress(GameObject playerChoice)
    {
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
}

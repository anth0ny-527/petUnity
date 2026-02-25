using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetGameManager : MonoBehaviour
{
    [Header("Input UI")]
    public TMP_InputField nameInputField;
    public Button submitButton;

    [Header("Pet Interaction Buttons")]
    public Button eatButton;
    public Button playButton;
    public Button restButton;
    public Button adoptNewPetButton;

    [Header("Pet Stats UI")]
    public TMP_Text petNameText;
    public TMP_Text hungerText;
    public TMP_Text boredomText;
    public TMP_Text tirednessText;
    public TMP_Text gameOverText;

    private Pet pet; //calls class

    private float timer = 0f;
    private  float statIncreaseInterval = 2f; //time between numbers going down

    void Start()
    {
        submitButton.interactable = false;
        

        eatButton.interactable = false;
        playButton.interactable = false;
        restButton.interactable = false;
        adoptNewPetButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);

        nameInputField.onValueChanged.AddListener(CheckNameInput);
    }

    void Update()
    {
        if (pet == null) return;

        timer += Time.deltaTime;

        if (timer >= statIncreaseInterval)
        {
        int hungerIncrease = Random.Range(1, 4);
        int boredomIncrease = Random.Range(1, 5);
        int tiredIncrease = Random.Range(1, 5);

        pet.Hunger += hungerIncrease;
        pet.Boredom += boredomIncrease;
        pet.Tiredness += tiredIncrease;
//random gain

            UpdateUI();
            CheckGameOver();

            timer = 0f;
        }
    }

    void CheckNameInput(string text)
    {
        submitButton.interactable = text.Length > 0;
    }

    public void CreatePet()
    {
        pet = new Pet(nameInputField.text);

        petNameText.text = "Pet Name: " + pet.Name;
        submitButton.gameObject.SetActive(false);
        nameInputField.gameObject.SetActive(false);
        eatButton.interactable = true;
        playButton.interactable = true;
        restButton.interactable = true;

        UpdateUI();
    }

    public void FeedPet()
    {
        if (pet == null) return;
        pet.Eat();
        UpdateUI();
    }

    public void PlayWithPet()
    {
        if (pet == null) return;
        pet.Play();
        UpdateUI();
    }

    public void RestPet()
    {
        if (pet == null) return;
        pet.Rest();
        UpdateUI();
    }

    void UpdateUI()
    { //maskes sure the ui is up to date
        hungerText.text = "Hunger: " + pet.Hunger;
        boredomText.text = "Boredom: " + pet.Boredom;
        tirednessText.text = "Tiredness: " + pet.Tiredness;
    }

    void CheckGameOver()
    {
        if (pet.Hunger >= 100 || pet.Boredom >= 100 || pet.Tiredness >= 100)
        { //checks all losing conditions
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Animal services took your pet away!";

            eatButton.interactable = false;
            playButton.interactable = false;
            restButton.interactable = false;

            adoptNewPetButton.gameObject.SetActive(true);

            pet = null;
        }
    }

    public void AdoptNewPet()
    {
        gameOverText.gameObject.SetActive(false);
        adoptNewPetButton.gameObject.SetActive(false);
  submitButton.gameObject.SetActive(true);
        nameInputField.gameObject.SetActive(true);
        petNameText.text = "";
        hungerText.text = "";
        boredomText.text = "";
        tirednessText.text = "";

        nameInputField.text = "";
        submitButton.interactable = false;
    }
}
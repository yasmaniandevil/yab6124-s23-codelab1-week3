using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private int money = 0;
    
    //name of folder where data will be stored
    const string DIR_DATA = "/Data/";
    //name of text file
    private const string FILE_MONEY_AMOUNT = "bank.txt";
    
    //Path to txt file
    private string PATH_MONEY_AMOUNT;

    //public const string PREF_MONEY_AMOUNT = "hsMoney";

    public int Money
    {
        get { return money; } //returns current value of var money
        set //sets value of money
        {
            money = value;
            Debug.Log("big money!!");

            if (money > BigMoney) 
                //if current amount collected is greater than Big money then set Big money to equal money just collected
            {
                BigMoney = money;
            }
        }
    }

    int bigMoney = 2;

    public int BigMoney
    {
        get
        {
            return bigMoney;
        }
        set
        {
            bigMoney = value;

            Directory.CreateDirectory((Application.dataPath + DIR_DATA));
            File.WriteAllText(PATH_MONEY_AMOUNT, "" + bigMoney);
        }
    }

    public int currentLevel = 0;

    public int targetMoney = 2;

    public TextMeshPro textMeshPro;

    private void Awake()
    {
        if (Instance == null)
        {
           DontDestroyOnLoad(gameObject);
           Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PATH_MONEY_AMOUNT = Application.dataPath + DIR_DATA + FILE_MONEY_AMOUNT;

        if (File.Exists(PATH_MONEY_AMOUNT))
        {
            BigMoney = Int32.Parse(File.ReadAllText(PATH_MONEY_AMOUNT));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //clears the money count
            File.Delete(PATH_MONEY_AMOUNT);
        }

        textMeshPro.text =
            "Level: " + (currentLevel + 1) + "\n" +
            "Money: " + money + "\n" + 
            "Most Money: " + BigMoney;

        if (money == targetMoney) //if we hit the right amount of moolah
        {
            currentLevel++; //increase level by 1
            targetMoney = targetMoney * 2; //increase the amount you have to get to go to next level
            SceneManager.LoadScene(currentLevel); //go to next level
        }
    }
}

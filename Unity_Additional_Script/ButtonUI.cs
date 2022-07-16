using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonUI : MonoBehaviour
{
    GameManager gameManager;   
    Text speedText;
    Text delayText;
    Text bulletSpeedText;
    Text bulletPowerText;
    Button speedUp;
    Button delayDown;
    Button BulletSpeedUp;
    Button BulletPowerUp;

    string new_Line = System.Environment.NewLine;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        speedText = GameObject.Find("SpeedText").GetComponent<Text>();
        delayText = GameObject.Find("DelayText").GetComponent<Text>();
        bulletSpeedText = GameObject.Find("BulletSpeedText").GetComponent<Text>();
        bulletPowerText = GameObject.Find("BulletPowerText").GetComponent<Text>();

        speedUp = GameObject.Find("SpeedButton").GetComponent<Button>();
        delayDown = GameObject.Find("DelayButton").GetComponent<Button>();
        BulletSpeedUp = GameObject.Find("BulletSpeedButton").GetComponent<Button>();
        BulletPowerUp = GameObject.Find("BulletPowerButton").GetComponent<Button>();

        speedUp.onClick.AddListener(SpeedUpClick);
        delayDown.onClick.AddListener(DelayDownClick);
        BulletSpeedUp.onClick.AddListener(BulletSpeedUpClick);
        BulletPowerUp.onClick.AddListener(BulletPowerUpClick);

        StartCoroutine(ButtonText());
    }

    void SpeedUpClick()
    {
        if(gameManager.speed < 2.9f)
        {
            gameManager.speed += 0.1f;
        }        
    }
    void DelayDownClick()
    {
        if(gameManager.delay > 0.06f)
        {
            gameManager.delay -= 0.01f;
        }
    }
    void BulletSpeedUpClick()
    {
        if(gameManager.bulletSpeed < 9.8f)
        {
            gameManager.bulletSpeed += 0.2f;
        }
    }
    void BulletPowerUpClick()
    {
        if (gameManager.bulletPower < 20)
        {
            gameManager.bulletPower += 1;
        }
    }
    IEnumerator ButtonText()
    {
        while (true)
        {
            speedText.text =
                "SPEED UP" + new_Line +
                "CURRENT SPEED : " + gameManager.speed.ToString("F1");

            delayText.text =
                "DELAY DOWN" + new_Line +
                "CURRENT DELAY : " + gameManager.delay.ToString("F2");

            bulletSpeedText.text =
                "BULLET SPEED" + new_Line +
                "CURRENT BULLET SPEED : " + gameManager.bulletSpeed.ToString("F1");

            bulletPowerText.text =
                "BULLET POWER" + new_Line +
                "CURRENT BULLET POWER : " + gameManager.bulletPower.ToString();

            yield return null;
        }
    }
}

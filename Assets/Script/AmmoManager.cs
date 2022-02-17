using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager instance = null;
    public static Text ammoText;
    public int magazine;
    public int ammoLeft;
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }
    void Start()
    {
        ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
        ammoLeft = magazine;
        UpdateText();

    }
    // Update is called once per frame
    public static void UpdateText()
    {
        ammoText.text = instance.ammoLeft.ToString() + "/" + instance.magazine.ToString();

    }
    public static void UseAmmo()
    {
        instance.ammoLeft--;
        AmmoManager.UpdateText();
    }
    public static void HideAmmo()
    {
        ammoText.gameObject.SetActive(false);
    }
    public static void ShowAmmo()
    {
        ammoText.gameObject.SetActive(true);
    }
}

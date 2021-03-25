using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLabyrinth : MonoBehaviour
{
    [SerializeField]
    InputField SizeIF;
    [SerializeField]
    InputField SeedIF;
    // Start is called before the first frame update
    void Start()
    {
        SeedIF.text = RandomString(15);
    }

    private static System.Random random = new System.Random();
    public static string RandomString(int length)
    {
        const string chars = "ÀÁÂÃÄÅ¨ÆÇÈÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßABCDEFGHIJKLMNOPQRSTUVWXYZàáâãäå¸æçèêëìíîïðñòóôõö÷øùúûüýþÿabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunLabyrinth()
    {
        if (SizeIF != null)
        {
            if (int.TryParse(SizeIF.text, out int size))
            {
                string seed = Guid.NewGuid().ToString();
                if (SeedIF != null)
                    seed = SeedIF.text;
                LabGenV2.OutSize = size;
                LabGenV2.OutSeed = seed;
                SceneManager.LoadScene(1);
            }
            else
            {
                SendMessage("Íå âåðíî óêàçàí ðàçìåð!");
            }
        }
    }
}

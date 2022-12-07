using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button LogInButton;

    // Start is called before the first frame update
    void Start()
    {
        LogInButton.onClick.AddListener(() =>{
            StartCoroutine(Main.Instance.Web.RegisterUser(UsernameInput.text, PasswordInput.text));
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

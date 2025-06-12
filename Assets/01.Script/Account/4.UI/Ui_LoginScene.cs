using System;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class Ui_InputFields
{
    public TextMeshProUGUI ResultText;
    public TMP_InputField IdInputField;
    public TMP_InputField NicknameInputField;
    public TMP_InputField PassWordInputField;
    public TMP_InputField PassWordConfirmInputField;

    public Button ConfirmButton;
}

public class Ui_LoginScene : MonoBehaviour
{
    [Header("패널")]
    public GameObject LoginPanel;
    public GameObject SingupPanel;

    [Header("Login")]
    public Ui_InputFields LoginInputField;

    [Header("Singup")]
    public Ui_InputFields SingupInputField;

    private void Start()
    {
        LoginPanel.SetActive(true);
        SingupPanel.SetActive(false);

        //LoginCheck();
    }


    public void OnClickGoToSingupPanel()
    {
        LoginPanel.SetActive(false);
        SingupPanel.SetActive(true);
    }
    public void OnClickGoToLoginPanel()
    {
        LoginPanel.SetActive(true);
        SingupPanel.SetActive(false);
    }

    public void SingUp()
    {
        //아디검증
        var emailSpecification = new AccountEmailSpecification();
        string email = SingupInputField.IdInputField.text;
        if (!emailSpecification.IsStatisfiedBy(email))
        {
            SingupInputField.ResultText.text = emailSpecification.ErrorMessage;
            SingupInputField.ResultText.gameObject.SetActive(true);
            return;
        }

        //비번검증
        var passwardSpecification = new AccountPasswardSPecification();
        string password = SingupInputField.PassWordInputField.text;
        if(passwardSpecification.IsStatisfiedBy(password))
        {
            SingupInputField.ResultText.text = passwardSpecification.ErrorMessage;
            SingupInputField.ResultText.gameObject.SetActive(true);
            return;
        }


        //비번 2번째 검증
        string passWordConfirm = SingupInputField.PassWordConfirmInputField.text;
        if (password != passWordConfirm && string.IsNullOrEmpty(password))
        {
            SingupInputField.ResultText.text = "비번 다시 확인하시오";
            SingupInputField.ResultText.gameObject.SetActive(true);
            return;
        }

        string nickname = "티모";
        if(AccountManager.Instance.TryRegister(email, nickname, password))
        {
            SingupInputField.ResultText.gameObject.SetActive(false);
            LoginInputField.IdInputField.text = email;

            OnClickGoToLoginPanel();
        }



    }
    public void Login()
    {

        //이메일 확인
        var emailSpecification = new AccountEmailSpecification();
        string email = LoginInputField.IdInputField.text;
        if(!emailSpecification.IsStatisfiedBy(email))
        {
            LoginInputField.ResultText.text = emailSpecification.ErrorMessage;
            LoginInputField.ResultText.gameObject.SetActive(true);
            return;
        }

        //비번확인
        var passwardSpecification = new AccountPasswardSPecification();
        string password = LoginInputField.PassWordInputField.text;

        //if(passwardSpecification.IsStatisfiedBy(password))
        //{
        //    LoginInputField.ResultText.text = passwardSpecification.ErrorMessage;
        //    LoginInputField.ResultText.gameObject.SetActive(true);
        //    return;
        //}

        if (!AccountManager.Instance.TryLogin(email, password))
        {
            LoginInputField.ResultText.text = "아이디나 비번 다시 확인하시오";
            LoginInputField.ResultText.gameObject.SetActive(true);
            return;
        }
        Debug.Log("로그인 성공함");
        SceneManager.LoadScene(1);
    }

    public void LoginCheck()
    {
        string id = LoginInputField.IdInputField.text;
        string password = LoginInputField.PassWordInputField.text;

        LoginInputField.ConfirmButton.enabled = !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(password);

    }



}

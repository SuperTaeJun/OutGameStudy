using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public static AccountManager Instance;
    private Account _myAccount;

    private AccountRepository _repository;

    public AccountDTO CurrentAccount => new AccountDTO(_myAccount);
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        Init();
    }

    private void Init()
    {
        _repository = new AccountRepository();
    }

    private const string SALT = "123456";
    public bool TryRegister(string email, string nickname, string password)
    {
        AccountSaveData saveData = _repository.Load(email);
        if(saveData !=null)
        {
            return false;
        }


        string encryptedPassward = CryptoUtil.Encryption(password, SALT);
        Account account = new Account(email, nickname, encryptedPassward);

        //레포 저장
        _repository.Save(new AccountDTO(account));


        return true; ;
    }
    public bool TryLogin(string email, string passward)
    {
        AccountSaveData savedData = _repository.Load(email);

        if (savedData == null)
        {
            Debug.Log("가입정보가 없음");
            return false;
        }

        if (email != savedData.Email)
        {
            return false;
        }
        if (!CryptoUtil.Verify(passward, savedData.Passward, SALT))
        {
            Debug.Log("비번검증 실패");
            return false;
        }

        _myAccount = new Account(savedData.Email, savedData.Nickname, savedData.Passward);
        return true;
    }





}

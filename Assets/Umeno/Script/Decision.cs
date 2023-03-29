using UnityEngine;
using UnityEngine.UI;

public class Decision : InstanceSystem<Decision>
{
    //各種パラメーターを格納する
    public class Parameter
    {
        public int _cute;
        public int _cool;
        public int _amuseing;
        public int _sexy;
        public int _ghostly;
        public Parameter(int a, int b, int c, int d, int e)
        {
            _cute = a;
            _cool = b;
            _amuseing = c;
            _sexy = d;
            _ghostly = e;
        }
    }

    [SerializeField, Tooltip("服のオブジェクト配列")] GameObject _clothesPanel;
    [SerializeField, Tooltip("靴のオブジェクト配列")] GameObject _shoesPanel;
    [SerializeField, Tooltip("アクセサリーのオブジェクト配列")] GameObject _accessoryPanel;
    [SerializeField] ParticleSystem _successEffect;
    [SerializeField] ParticleSystem _failedEffect;
    [SerializeField] GameObject[] _bgms;
    //服のパラメーターを格納する変数
    public Parameter _clothes = new Parameter(0, 0, 0, 0, 0);
    //靴のパラメーターを格納する変数
    public Parameter _shoes = new Parameter(0, 0, 0, 0, 0);
    //アクセサリーのパラメーターを格納する変数
    public Parameter _accessory = new Parameter(0, 0, 0, 0, 0);
    //客のパラメーターを格納する変数
    public Parameter _customer = new Parameter(3, 3, 3, 3, 3);
    GameManager _gameManager;
    Button _decisionButton;
    CustomerController _customerControlle;
    CustomerGenerator _customerGenerator;



    //プロパティ化
    public Parameter Clothes { get => _clothes; set => _clothes = value; }
    public Parameter Shoes { get => _shoes; set => _shoes = value; }
    public Parameter Accessory { get => _accessory; set => _accessory = value; }
    public Parameter Customer { get => _customer; set => _customer = value; }
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _decisionButton = GetComponent<Button>();
        _customerGenerator = FindObjectOfType<CustomerGenerator>();
        _customerGenerator.Generate();
    }
    private void OnEnable()
    {
        _gameManager.OnGameEnd += BgmChange;

    }
    private void OnDisable()
    {
        _gameManager.OnGameEnd -= BgmChange;
    }
    public void BgmChange()
    {
        _bgms[0].SetActive(false);
        _bgms[1].SetActive(true);
    }
    private void Update()
    {
        if(!_gameManager.IsGame)
        {
            _decisionButton.enabled = false;
        }
        else
        {
            _decisionButton.enabled = true;
        }
    }
    public void DecisionButton()
    {
        AudioController.Instance.SePlay(SelectAudio.Select);
        _customerControlle = FindObjectOfType<CustomerController>();
        _customerGenerator = FindObjectOfType<CustomerGenerator>();
        _customerControlle.ImageChange(false);
        //服と靴とアクセサリーのcute値を合計
        int cute = _clothes._cute + _shoes._cute + _accessory._cute;
        //服と靴とアクセサリーのcool値を合計
        int cool = _clothes._cool + _shoes._cool + _accessory._cool;
        //服と靴とアクセサリーのamuseing値を合計
        int amuseing = _clothes._amuseing + _shoes._amuseing + _accessory._amuseing;
        //服と靴とアクセサリーのsexy値を合計
        int sexy = _clothes._sexy + _shoes._sexy + _accessory._sexy;
        //服と靴とアクセサリーのghostly値を合計
        int ghostly = _clothes._ghostly + _shoes._ghostly + _accessory._ghostly;
        this._clothes = new Parameter(0, 0, 0, 0, 0);
        this._shoes = new Parameter(0, 0, 0, 0, 0);
        this._accessory = new Parameter(0, 0, 0, 0, 0);
        this._customer = new Parameter(3, 3, 3, 3, 3);
        for (int i = 0; i < 5; i++)
        {
            _clothesPanel.transform.GetChild(i).SetSiblingIndex(Random.Range(0, 6));
            _shoesPanel.transform.GetChild(i).SetSiblingIndex(Random.Range(0, 6));
            _accessoryPanel.transform.GetChild(i).SetSiblingIndex(Random.Range(0, 6));
        }
        for (int i = 0; i < _customerControlle.Dresses.Length; i++)
        {
            _customerControlle.Dresses[i].SetActive(false);
            _customerControlle.Shoes[i].SetActive(false);
            _customerControlle.Accessories[i].SetActive(false);
        }
        Debug.Log($"服のオーダー　Cute:{cute} Cool:{cool} Amuseing{amuseing} Sexy{sexy} Ghostly{ghostly}");
        Debug.Log($"客のオーダー　Cute:{Customer._cute} Cool:{Customer._cool} Amuseing{Customer._amuseing} Sexy{Customer._sexy} Ghostly{Customer._ghostly}");
        //客の満足度によってスコアを変える
        if (this._customer._cute <= cute && this._customer._cool <= cool && this._customer._amuseing <= amuseing && this._customer._sexy <= sexy && this._customer._ghostly <= ghostly)
        {
            _successEffect.Play();
            _gameManager.AddScore(15000);
            _customerControlle.VerryGoodPlay();
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("大満足");
        }
        else if (this._customer._cute < cute)
        {
            _gameManager.AddScore(3000);
            _customerControlle.GoodPlay();
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("満足");
        }
        else if (this._customer._cool < cool)
        {
            _gameManager.AddScore(3000);
            _customerControlle.GoodPlay();
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("満足");
        }
        else if (this._customer._amuseing < amuseing)
        {
            _gameManager.AddScore(3000);
            _customerControlle.GoodPlay();
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("満足");
        }
        else if (this._customer._sexy < sexy)
        {
            _gameManager.AddScore(3000);
            _customerControlle.GoodPlay();
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("満足");
        }
        else if (this._customer._ghostly < ghostly)
        {
            _gameManager.AddScore(3000);
            _customerControlle.GoodPlay();
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("満足");
        }
        else
        {
            _failedEffect.Play();
            _gameManager.AddScore(10);
            _customerControlle.MissPlay();
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("不満");
        }
    }
}

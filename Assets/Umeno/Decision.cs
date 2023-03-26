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


    //プロパティ化
    public Parameter Clothes { get => _clothes; set => _clothes = value; }
    public Parameter Shoes { get => _shoes; set => _shoes = value; }
    public Parameter Accessory { get => _accessory; set => _accessory = value; }
    public Parameter Customer { get => _customer; set => _customer = value; }

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _decisionButton = GetComponent<Button>();
    }
    private void Update()
    {
        if(!_gameManager.IsGame)
        {
            _decisionButton.enabled = false;
        }
    }
    public void DecisionButton()
    {
        CustomerController customer = FindObjectOfType<CustomerController>();
        CustomerGenerator customerGenerator = FindObjectOfType<CustomerGenerator>();
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
        for(int i = 0; i < 5; i++)
        {
            _clothesPanel.transform.GetChild(i).SetSiblingIndex(Random.Range(0, 6));
            _shoesPanel.transform.GetChild(i).SetSiblingIndex(Random.Range(0, 6));
            _accessoryPanel.transform.GetChild(i).SetSiblingIndex(Random.Range(0, 6));
        }
        //客の満足度によってスコアを変える
        if (_customer._cute <= cute && _customer._cool <= cool && _customer._amuseing <= amuseing && _customer._sexy <= sexy && _customer._ghostly <= ghostly)
        {
            for(int i = 0; i < customer.Dresses.Length; i++)
            {
                customer.Dresses[i].SetActive(false);
                customer.Shoes[i].SetActive(false);
                customer.Accessories[i].SetActive(false);
            }
            _gameManager.AddScore(500);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("大満足");
        }
        else if (_customer._cute < cute)
        {
            _gameManager.AddScore(100);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("満足");
        }
        else if (_customer._cool < cool)
        {
            _gameManager.AddScore(100);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("満足");
        }
        else if (_customer._amuseing < amuseing)
        {
            _gameManager.AddScore(100);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("満足");
        }
        else if (_customer._sexy < sexy)
        {
            _gameManager.AddScore(100);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("満足");
        }
        else if (_customer._ghostly < ghostly)
        {
            _gameManager.AddScore(100);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("満足");
        }
        else
        {
            _gameManager.AddScore(10);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("不満");
        }
    }
}

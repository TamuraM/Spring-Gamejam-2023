using UnityEngine;
using UnityEngine.UI;

public class Decision : InstanceSystem<Decision>
{
    //�e��p�����[�^�[���i�[����
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

    [SerializeField, Tooltip("���̃I�u�W�F�N�g�z��")] GameObject _clothesPanel;
    [SerializeField, Tooltip("�C�̃I�u�W�F�N�g�z��")] GameObject _shoesPanel;
    [SerializeField, Tooltip("�A�N�Z�T���[�̃I�u�W�F�N�g�z��")] GameObject _accessoryPanel;
    //���̃p�����[�^�[���i�[����ϐ�
    public Parameter _clothes = new Parameter(0, 0, 0, 0, 0);
    //�C�̃p�����[�^�[���i�[����ϐ�
    public Parameter _shoes = new Parameter(0, 0, 0, 0, 0);
    //�A�N�Z�T���[�̃p�����[�^�[���i�[����ϐ�
    public Parameter _accessory = new Parameter(0, 0, 0, 0, 0);
    //�q�̃p�����[�^�[���i�[����ϐ�
    public Parameter _customer = new Parameter(3, 3, 3, 3, 3);
    GameManager _gameManager;
    Button _decisionButton;


    //�v���p�e�B��
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
        //���ƌC�ƃA�N�Z�T���[��cute�l�����v
        int cute = _clothes._cute + _shoes._cute + _accessory._cute;
        //���ƌC�ƃA�N�Z�T���[��cool�l�����v
        int cool = _clothes._cool + _shoes._cool + _accessory._cool;
        //���ƌC�ƃA�N�Z�T���[��amuseing�l�����v
        int amuseing = _clothes._amuseing + _shoes._amuseing + _accessory._amuseing;
        //���ƌC�ƃA�N�Z�T���[��sexy�l�����v
        int sexy = _clothes._sexy + _shoes._sexy + _accessory._sexy;
        //���ƌC�ƃA�N�Z�T���[��ghostly�l�����v
        int ghostly = _clothes._ghostly + _shoes._ghostly + _accessory._ghostly;
        for(int i = 0; i < 5; i++)
        {
            _clothesPanel.transform.GetChild(i).SetSiblingIndex(Random.Range(0, 6));
            _shoesPanel.transform.GetChild(i).SetSiblingIndex(Random.Range(0, 6));
            _accessoryPanel.transform.GetChild(i).SetSiblingIndex(Random.Range(0, 6));
        }
        //�q�̖����x�ɂ���ăX�R�A��ς���
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
            Debug.Log("�喞��");
        }
        else if (_customer._cute < cute)
        {
            _gameManager.AddScore(100);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("����");
        }
        else if (_customer._cool < cool)
        {
            _gameManager.AddScore(100);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("����");
        }
        else if (_customer._amuseing < amuseing)
        {
            _gameManager.AddScore(100);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("����");
        }
        else if (_customer._sexy < sexy)
        {
            _gameManager.AddScore(100);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("����");
        }
        else if (_customer._ghostly < ghostly)
        {
            _gameManager.AddScore(100);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("����");
        }
        else
        {
            _gameManager.AddScore(10);
            customer.gameObject.SetActive(false);
            customerGenerator.Generate();
            Debug.Log("�s��");
        }
    }
}

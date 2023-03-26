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
    [SerializeField] ParticleSystem _successEffect;
    [SerializeField] ParticleSystem _failedEffect;
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
    CustomerController _customerControlle;
    CustomerGenerator _customerGenerator;



    //�v���p�e�B��
    public Parameter Clothes { get => _clothes; set => _clothes = value; }
    public Parameter Shoes { get => _shoes; set => _shoes = value; }
    public Parameter Accessory { get => _accessory; set => _accessory = value; }
    public Parameter Customer { get => _customer; set => _customer = value; }

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _decisionButton = GetComponent<Button>();
        _customerGenerator = FindObjectOfType<CustomerGenerator>();
        _customerGenerator.Generate();
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
        _customerControlle = FindObjectOfType<CustomerController>();
        _customerGenerator = FindObjectOfType<CustomerGenerator>();
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
        this._clothes = new Parameter(0, 0, 0, 0, 0);
        this._shoes = new Parameter(0, 0, 0, 0, 0);
        this._accessory = new Parameter(0, 0, 0, 0, 0);
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
        //�q�̖����x�ɂ���ăX�R�A��ς���
        if (this._customer._cute <= cute && this._customer._cool <= cool && this._customer._amuseing <= amuseing && this._customer._sexy <= sexy && this._customer._ghostly <= ghostly)
        {
            _successEffect.Play();
            _gameManager.AddScore(15000);
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("�喞��");
        }
        else if (this._customer._cute < cute)
        {
            _gameManager.AddScore(3000);
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("����");
        }
        else if (this._customer._cool < cool)
        {
            _gameManager.AddScore(3000);
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("����");
        }
        else if (this._customer._amuseing < amuseing)
        {
            _gameManager.AddScore(3000);
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("����");
        }
        else if (this._customer._sexy < sexy)
        {
            _gameManager.AddScore(3000);
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("����");
        }
        else if (this._customer._ghostly < ghostly)
        {
            _gameManager.AddScore(3000);
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("����");
        }
        else
        {
            _failedEffect.Play();
            _gameManager.AddScore(10);
            _customerControlle.gameObject.SetActive(false);
            _customerGenerator.Generate();
            Debug.Log("�s��");
        }
    }
}

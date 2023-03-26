using UnityEngine;

public class Decision : InstanceSystem<Decision>
{
    public class Parameter
    {
        public int cute;
        public int cool;
        public int amuseing;
        public int sexy;
        public int ghostly;
        public Parameter(int a, int b, int c, int d, int e)
        {
            cute = a;
            cool = b;
            amuseing = c;
            sexy = d;
            ghostly = e;

        }
    }

    Parameter _clothes = new Parameter(0, 0, 0, 0, 0);
    Parameter _shoes = new Parameter(0, 0, 0, 0, 0);
    Parameter _accessory = new Parameter(0, 0, 0, 0, 0);
    //服の変数
    public Parameter Clothes { get => _clothes; set => _clothes = value; }
    //靴の変数
    public Parameter Shoes { get => _shoes; set => _shoes = value; }
    //アクセサリーの変数
    public Parameter Accessory { get => _accessory; set => _accessory = value; }
    void Start()
    {
    }
    void Update()
    {
        
    }
}

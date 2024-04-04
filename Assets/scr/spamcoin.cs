using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spamcoin : MonoBehaviour
{
    public Transform _player; //ánh xạ tới nhân vật
    public GameObject _coin; //ánh xạ tới prefab coin
    public float _nextPosX;
    public float _nextPosY; //Vị trí sẽ sinh ra coin
    private float _khoangCach; //Khoảng cách coin cách ra với người chơi
    //độ cong hình sin
    public float _chieuCaoSin;
    public float TOADO;
    public float _doRongSin;
    public float _chieuCao; //chiều cao so với mặt đất của coin
    public float _chieuCaoToiThieu;
    public float _thoiGian; //Bao lâu vẽ coin 1 lần
    public int _soLuongCoin; //Số lượng coin mỗi lần vẽ ra
   
    public float _timer; //Theo dõi thời gian
    private Vector3 nextPos;

    void Start()
    {
        _khoangCach = 26f;
        _chieuCaoToiThieu = 0f;
        _thoiGian = 4f;
        _soLuongCoin = 11;
        _timer = 0;
        VeCoin2();
        

    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _thoiGian)
        {
            VeCoin2();
            _timer = 0;
        }
    }

    private void veCoin()
    {
        _chieuCao = Random.Range(0.5f, 1.1f) + _chieuCaoToiThieu;
        _chieuCaoSin = 1f;
        _doRongSin = 1f;
        //_doCong = Random.Range(0.8f, 1.2f);
        _nextPosX = _player.position.x + _khoangCach;
        for (int i = 0; i < _soLuongCoin; i++)
        {
            _nextPosY = Mathf.Abs(_chieuCaoSin * Mathf.Sin(_nextPosX / _doRongSin)) + _chieuCao;
           
            Instantiate(_coin, new Vector3(_nextPosX, _nextPosY, 12f), Quaternion.identity, transform);
            _nextPosX++;
        }
    }
    private void VeCoin2()
    {
        float a = 0.05f; // Giá trị của a không đổi
        float b = -1.0f; // Giảm giá trị của b để các đồng xu gần mặt đất hơn
        nextPos = _player.position + new Vector3(_khoangCach,0,12f);
        int socoin2 = (int)(_soLuongCoin / 2);
        for(int i = -1* socoin2; i<= socoin2; i++)
        {
            Vector3 ToaDo = nextPos + new Vector3(i + socoin2, -1 * a * i * i + a * _soLuongCoin * _soLuongCoin / 4 + b, 0f);
                 Instantiate(_coin , ToaDo, Quaternion.identity, transform);
        }
    }
}

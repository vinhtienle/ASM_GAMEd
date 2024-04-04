using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thanhmau : MonoBehaviour
{
    public Image _ThanhMau;

    public void capnhatthanhmau(float LuongMauHienTai, float LuongMauToiDa)
    {
        _ThanhMau.fillAmount = LuongMauHienTai / LuongMauToiDa;
    }
}

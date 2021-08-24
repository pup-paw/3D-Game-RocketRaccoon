using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지

//감지된 입력값을 다른 컴포넌트가 사용헐 수 있도록 제공
public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical";  //앞뒤 움직임을 위한 입력축 이름
    public string rotateAxisName = "Horizontal";   //좌우 회전을 위한 입력축 이름

    public float move { get; private set; }  //감지된 움직임 입력값
    public float rotate { get; private set; } //감지된 회전 입력값

    // Update is called once per frame 
    private void Update()
    {
        move = Input.GetAxis(moveAxisName);
        rotate = Input.GetAxis(rotateAxisName);
    }
}
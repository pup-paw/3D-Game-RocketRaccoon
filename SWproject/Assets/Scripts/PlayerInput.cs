using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//�÷��̾� ĳ���͸� �����ϱ� ���� ����� �Է��� ����

//������ �Է°��� �ٸ� ������Ʈ�� ����� �� �ֵ��� ����
public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical";  //�յ� �������� ���� �Է��� �̸�
    public string rotateAxisName = "Horizontal";   //�¿� ȸ���� ���� �Է��� �̸�

    public float move { get; private set; }  //������ ������ �Է°�
    public float rotate { get; private set; } //������ ȸ�� �Է°�

    // Update is called once per frame 
    private void Update()
    {
        move = Input.GetAxis(moveAxisName);
        rotate = Input.GetAxis(rotateAxisName);
    }
}
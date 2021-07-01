using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController: MonoBehaviour
{
    //�{�[����������\���̂��肚���̍ő�l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject gameoverText;

    //�����蔻��̃R���|�[�l���g������y�ۑ�z

    private Rigidbody myRigidbody;

    //��ʉE���Score��\������@�y�ۑ�z

    private GameObject ScoreText;

    //���_�@�y�ۑ�z

    private int score = 0;




    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody�R���|�[�l���g���擾

        this.myRigidbody = GetComponent<Rigidbody>();


        //�V�[������GameOverText�I�u�W�F�N�g���K��
        this.gameoverText = GameObject.Find("GameOverText");


        //�V�[������ScoreText�I�u�W�F�N�g���擾

        this.ScoreText = GameObject.Find("ScoreText");


    }

    // Update is called once per frame
    void Update()
    {
         //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverText��Game Over��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //�{�[�����I�u�W�F�N�g�ƐڐG�����ꍇ�̏����y�ۑ�z
    void OnCollisionEnter(Collision other)
    {
        //�{�[�����������_,�傫�����ɏՓ˂����ꍇ

        if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeStarTag")
        {
            this.score += 10;
        }
        //�{�[�����傫���_�ɏՓ˂����ꍇ

        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.score += 50;
        }
        //�{�[�������������ɏՓ˂����ꍇ
        else if (other.gameObject.tag == "SmallStarTag")
        {
            this.score += 1;
        }

        //ScoreText�Ɋl�������_����\��
        this.ScoreText.GetComponent<Text>().text = this.score + "pt";
    }



}



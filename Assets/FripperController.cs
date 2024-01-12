using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start ()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
     void Update ()
    {

        //左矢印キーまたはAキーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag" || Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle (this.flickAngle);
        }
        //右矢印キーまたはDキーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag" || Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle (this.flickAngle);
        }
        //下矢印キーまたはSキーを押した時同時に左右のフリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && (tag == "LeftFripperTag" || tag == "RightFripperTag"))
        {
            SetAngle (this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag" || Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle (this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag" || Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle (this.defaultAngle);
        }
        //下矢印キーまたはSキーを離したときフリッパーを元に戻す
        if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && (tag == "LeftFripperTag" || tag == "RightFripperTag"))
        {
            SetAngle (this.defaultAngle);
        }
    }


    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}

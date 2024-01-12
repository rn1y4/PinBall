using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalc : MonoBehaviour
{
    //スコア
    private int score = 0;

    //スコアを表示するテキスト
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
       this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {

        //衝突したオブジェクトのTagにより異なるスコアを加算
        if (other.gameObject.tag == "SmallStarTag")
        {
            AddScore(5);
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            AddScore(10);
        }
        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            AddScore(20);
        }
    }

    void AddScore(int amount)
    {
        this.score += amount;
        //スコアを表示
        this.scoreText.GetComponent<Text> ().text = this.score.ToString();
    }

}

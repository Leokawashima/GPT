﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderKeywordFilter.FilterAttribute;

/// <summary>
/// 先攻後攻用
/// </summary>
public class Order : MonoBehaviour
{
    protected enum StateOrder
    {
        Non, //まだ決まっていない
        First, //先攻
        Second //後攻
    }

    [SerializeField] Button FirstAttackButton; //先攻ボタン
    [SerializeField] Button SecondAttack; //後攻ボタン
    [SerializeField] Button DecideButton; //決定ボタン
    [SerializeField] Image SelectImage; //選択したボタンが分かりやすいように作成した画像
    [SerializeField] Text InductionText; //プレイヤーがするべきことへ誘導するテキスト
    protected StateOrder order = StateOrder.Non; //先攻、後攻が決まるまで何も決まっていない状態にしておく


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(order);

        FirstAttackButton.onClick.AddListener(First_);
        SecondAttack.onClick.AddListener(Second_);
        DecideButton.onClick.AddListener(Decide);

        SelectImage.enabled = false;

        InductionText.text = "先攻 後攻を選んでください";
    }

    #region Button
    //PrecedenceButtonが押されたとき
    void First_()
    {
        SelectImage.enabled = true;
        SelectImage.transform.position = FirstAttackButton.transform.position + new Vector3(200, 98, 0);
        order = StateOrder.First;
        Debug.Log(order);

        InductionText.text = "先攻でよろしいでしょうか";
    }

    //FollowerButtonが押されたとき
    void Second_()
    {
        SelectImage.enabled = true;
        SelectImage.transform.position = SecondAttack.transform.position + new Vector3(200, 98, 0);
        order = StateOrder.Second;
        Debug.Log(order);

        InductionText.text = "後攻でよろしいでしょうか";
    }

    //DecideButtonが押されたとき
    void Decide()
    {
        //先攻、後攻が選択されていない場合、この先の処理は行わない
        if (order == StateOrder.Non) return;

        gameObject.SetActive(false);
    }
    #endregion
}

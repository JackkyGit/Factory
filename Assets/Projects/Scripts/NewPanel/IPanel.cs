using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanel
{
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="manager"></param>
    void Init(ManagerBase manager);
    /// <summary>
    /// 获取数据
    /// </summary>
    /// <param name="dataIO"></param>
    void GetDataFromGetter(IDataIO dataIO);
    /// <summary>
    /// 设置数据
    /// </summary>
    void SetData();
    /// <summary>
    /// 设置自定义界面数据
    /// </summary>
    void SetCustomData();
    /// <summary>
    /// 监听信息
    /// </summary>
    /// <param name="msgid"></param>
    /// <param name="handle"></param>
    void Subscribe(int msgid, Action<MessageArg> handle);
    /// <summary>
    /// 发送信息
    /// </summary>
    /// <param name="msgid"></param>
    /// <param name="managerID"></param>
    /// <param name="arg"></param>
    void SendMsg(int msgid, ManagerID managerID, MessageArg arg);

    void ShowOnEffect();
}

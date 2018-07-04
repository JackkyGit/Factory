using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControl
{
    void Control(MessageArg arg);
    void OffControl();
}

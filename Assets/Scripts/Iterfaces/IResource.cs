using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResource
{
    ResourceType GetResType();
    string GetID();

    void SetID(string id);
}

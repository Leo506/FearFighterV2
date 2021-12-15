using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhraseResource : IResource
{
    public Dictionary<string, string> text;
    string id;

    public PhraseResource()
    {
        text = new Dictionary<string, string>();
    }

    public ResourceType GetResType()
    {
        return ResourceType.TEXT_RES;
    }


    public string GetID()
    {
        return  id;
    }


    public void SetID(string id)
    {
        this.id = id;
    }
}

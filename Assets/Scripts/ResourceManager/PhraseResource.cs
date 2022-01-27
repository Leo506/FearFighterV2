using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Question
{
	public int id;                // id вопроса
	public string questionText;   // Текст вопроса
	public List<string> answers;  // Варианты ответа
	public string rightAnswer;    // Правильный ответ

	public override string ToString()
	{
		return $"Question id: {id}, text: {questionText}, right: {rightAnswer}";
	}
}


public class PhraseResource : IResource
{
    public List<Question> questions;
    string id;

    public PhraseResource()
    {
        questions = new List<Question>();
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

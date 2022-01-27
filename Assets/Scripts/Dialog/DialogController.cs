using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DialogController : MonoBehaviour, ISetUpObj
{
    // TODO поменять PhraseResource на QuestionsResource
    PhraseResource questions;  // Вопросы от босса

    Canvas canvas;
    BossFight.UIController ui;
    BossFightPhase2.Boss boss;

    int currentQuestionId;

    [SerializeField] string[] canvasToClose;

    public void SetUp() {
        StartDialog(0);
    }


    /// <summary>
    /// Начинает диалог с боссом; босс задаёт вопрос с определённым id
    /// </summary>
    /// <param name="id">id вопроса</param>
    public void StartDialog(int id)
    {
        foreach (var item in canvasToClose)
        {
            GameObject.FindWithTag(item).GetComponent<Canvas>().enabled = false;
        }

        boss = (BossFightPhase2.Boss)FindObjectOfType<EnemyController>();
        boss.StopMovement(false);

        canvas = GetComponent<Canvas>();
        canvas.enabled = true;

        currentQuestionId = id;

        ui = GetComponent<BossFight.UIController>();
        ui.Init(this);

        StartCoroutine(LoadQuestions());
    }


    IEnumerator LoadQuestions()
    {
        // Определение пути к файлу с вопросами
        string path = "";
        #if UNITY_EDITOR
            path = "file://" + Application.streamingAssetsPath + $"/BossStrings/Boss0.xml";
        #else
            path = "jar:file://" + Application.dataPath + $"!/assets/BossStrings/Boss0.xml";
        #endif

        ResourceManager manager = new ResourceManager();

        // Загрузка вопросов из файла
        if (!manager.ResourceLoaded(ResourceType.TEXT_RES, path))
            yield return manager.LoadResource(ResourceType.TEXT_RES, path);

        questions = new PhraseResource();
        questions.questions = (manager.GetResource(ResourceType.TEXT_RES, path) as PhraseResource).questions;



        Question currentQuestion = questions.questions.Where(q => q.id == currentQuestionId).ToArray()[0];  // Текущий вопрос
        string qText = currentQuestion.questionText;                                                        // Текст текущего вопроса
        List<string> qAns = currentQuestion.answers;                                                        // Ответы текущего вопроса
        ui.ShowText(qText);
        ui.SetButtons(qAns);
    }


    public void OnPressedButton(string txt)
    {
        string right = questions.questions.Where(q => q.id == currentQuestionId).ToArray()[0].rightAnswer;
        if (right == txt)
        {
            boss.GetDamage(20);
        } else
            PlayerLogic.instance.GetDamage(20);
        
        canvas.enabled = false;
        foreach (var item in canvasToClose)
        {
            GameObject.FindWithTag(item).GetComponent<Canvas>().enabled = true;
        }
        boss.StopMovement(true);
    }
}

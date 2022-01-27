using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

namespace BossFight
{
	public class UIController : MonoBehaviour
	{
	    [SerializeField] Text bossText;            // Куда выводится текст
		[SerializeField] Button[] answerButtons;   // Кнопки выбора ответа
		DialogController dialog;


		/// <summary>
		/// Инициализация UI Controller
		/// </summary>
		/// <param name="controller">Контроллер диалога</param>
		public void Init(DialogController controller)
		{
			dialog = controller;
		}


		/// <summary>
		/// Показывает текст на экране
		/// </summary>
		/// <param name="text">Текст</param>
	    public void ShowText(string text)
		{
			StartCoroutine(Showing(text));
		}

		IEnumerator Showing(string text)
		{
			string tmp = "";
			foreach (var letter in text)
			{
				tmp += letter;
				bossText.text = tmp;
				yield return new WaitForSeconds(0.1f);
			}
		}


		/// <summary>
		/// Устанавливает текст на кнопках ответа
		/// </summary>
		/// <param name="btnText">Список текстов на кнопках</param>
		public void SetButtons(List<string> btnText)
		{
			for	(int i = 0; i < answerButtons.Length; i++)
			{
				answerButtons[i].gameObject.GetComponentInChildren<Text>().text = btnText[i];
			}
		}


		public void PressButton(Text txt)
		{
			dialog.OnPressedButton(txt.text);
		}
	}
}

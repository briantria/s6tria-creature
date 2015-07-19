using UnityEngine;
using UnityEngine.UI;

public class ChipDataDisplay : MonoBehaviour 
{
	[SerializeField] private Text m_textLabel;
	private ChipData m_chipData;

	public int id { set; get; }
	public string description { set; get; }

	public ChipData chipData
	{
		set
		{
			m_chipData = value;
			id = m_chipData.id;
			label = m_chipData.label;
			description = m_chipData.description;
		}

		get
		{
			return m_chipData;
		}
	}

	public string label
	{
		set
		{
			m_textLabel.text = value;
		}

		get
		{
			return m_textLabel.text;
		}
	}
}

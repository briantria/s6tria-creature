using UnityEngine;
using UnityEngine.UI;

public class ChipDataDisplay : MonoBehaviour 
{
	[SerializeField] private Text m_textLabel;

	public int id { set; get; }
	public string description { set; get; }

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

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{
    public class StoryNode
    {
        public string _text;
        public List<StoryOption> _options;
    }

    public class StoryOption
    {
        public string _optionText;
        public StoryNode _nextNode;
    }

    public Text _storyText;
    public Button[] _optionButtons;
    public GameObject _dialogueUI;
    public Collider _triggerZone;

    private StoryNode _currentNode;
    public StoryNode _initialNode;

    public void Start()
    {
        _dialogueUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider p_other)
    {
        if(p_other.CompareTag("Player"))
        {
            _dialogueUI.SetActive(true);
            LoadStoryNode(_initialNode);
        }
    }

    public void LoadStoryNode(StoryNode p_node)
    {
        _currentNode = p_node;
        _storyText.text = p_node._text;

        for (int i = 0; i < p_node._options.Count; i++) 
        {
            _optionButtons[i].gameObject.SetActive(true);
            _optionButtons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
        }

        for (int i = p_node._options.Count; i < _optionButtons.Length; i++) 
        {
            _optionButtons[i].gameObject.SetActive(false);
        }
    }

    public void ChooseOption(int p_optionIndex)
    {
        StoryNode nextNode = _currentNode._options[p_optionIndex]._nextNode;
        LoadStoryNode(nextNode);
    }
}

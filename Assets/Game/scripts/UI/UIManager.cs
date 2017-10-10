using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UIManager : MonoBehaviour {
	
	private static UIManager _instance;

	public static UIManager Instance { get { return _instance; } }

	//存放现有面板
	private Stack<UIBase> UIStack = new Stack<UIBase> ();

	private Dictionary<string,UIBase> currentUIDict = new Dictionary<string,UIBase> ();

	private Dictionary<string,GameObject> UIObjectDict = new Dictionary<string,GameObject> ();

	public string ResourceDir = "UI";

	void Awake()
	{
		_instance = this;

		AddUIBase ("UIStartup");
		AddUIBase ("UISetting");
		AddUIBase ("UIPlaying");
		AddUIBase ("UILose");
		AddUIBase ("UIWin");
	}

	//入栈 把名字显示出来
	public void PushUIPanel(string UIName)
	{
		if(UIStack.Count > 0)
		{
			UIBase old_topUI = UIStack.Peek();
			old_topUI.DoOnPausing();
		}

		UIBase new_topUI = GetUIBase(UIName);
		new_topUI.DoOnEntering();
		UIStack.Push(new_topUI);
	}

	private UIBase GetUIBase(string UIName)
	{
		foreach (var name in currentUIDict.Keys) 
		{
			if (name == UIName) {
				UIBase u = currentUIDict [UIName];
				return u;
			}
		}

		//如果没有 就先得到面板的prefab
		GameObject UIPrefab = UIObjectDict [UIName];
		GameObject UIObject = GameObject.Instantiate<GameObject> (UIPrefab);
		UIObject.name = UIName;
		UIBase uibase = UIObject.GetComponent<UIBase> ();
		currentUIDict.Add (UIName, uibase);
		return uibase;
	}

	//出栈 把界面隐藏
	public void PopUIPanel()
	{
		if (UIStack.Count == 0)
			return;
		
		UIBase old_topUI = UIStack.Pop ();
		old_topUI.DoOnExiting ();

		if (UIStack.Count > 0) {
			UIBase new_topUI = UIStack.Peek ();
			new_topUI.DoOnResuming ();
		}
	}

	public void AddUIBase(string UIName)
	{
		string UIPath = ResourceDir + "/" + UIName;
		GameObject UIObject = Resources.Load<GameObject>(UIPath);
		if (UIObject)
			UIObjectDict.Add(UIName, UIObject);
	}
}

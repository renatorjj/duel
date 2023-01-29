using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Canvas))]
public class UIManager : MonoBehaviour
{
    private Dictionary<string, UIScreen> _screens;
    private UIScreen _currentScreen;
    private List<UIScreen> _activeScreens;
    private static UIManager _instance;
    
    public static void Show(string screenName) => _instance.ShowScreen(screenName);

    public static void Hide(string screenName) => _instance.HideScreen(screenName);

    public static UIScreen GetScreenByName(string screenName) => _instance._screens.ContainsKey(screenName) ? _instance._screens[screenName] : null;
    
    protected void Awake()
    {
      Init();
    }

    private void Init()
    {
      _instance = this;
      _activeScreens = new List<UIScreen>();
      FindScreens();
    }

    private void ShowScreen(string screenName)
    {
      UIScreen screenByName = GetScreenByName(screenName);
      if (screenByName != null)
      {
        if (_currentScreen != null)
        {
          HideScreen(_currentScreen);
        }
        _currentScreen = screenByName; 
        _currentScreen.Show();
        if (!_activeScreens.Contains(_currentScreen))
        {
          _activeScreens.Add(_currentScreen);
        }
      }
      else
      {
        Debug.LogWarning($"[UIManager][ShowScreen] {screenName} not found");
      }
    }

    private void HideScreen(string screenName)
    {
      UIScreen screenByName = GetScreenByName(screenName);
      if (screenByName != null)
      {
        HideScreen(screenByName);
      }
      else
      {
        Debug.LogWarning($"[UIManager][HideScreen] {screenName} not found");
      }
    }

    private void HideScreen(UIScreen screen)
    {
      if (screen != null)
      {
        if (_currentScreen != null && screen == _currentScreen)
        {
          _currentScreen = null;
        }
        
        screen.Hide();
        if (_activeScreens.Contains(screen))
        {
          _activeScreens.Remove(screen);
        }
      }
      else
      {
        Debug.LogWarning("[UIManager][HideScreen] screen is null" );
      }
    }

    private void FindScreens()
    {
      _screens = new Dictionary<string, UIScreen>();
      foreach (var componentsInChild in GetComponentsInChildren<UIScreen>(true))
      {
        componentsInChild.Init();
        _screens.Add(componentsInChild.name, componentsInChild);
      }
    }
}

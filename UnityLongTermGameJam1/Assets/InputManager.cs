// GENERATED AUTOMATICALLY FROM 'Assets/InputManager.inputactions'

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Input;


[Serializable]
public class InputManager : InputActionAssetReference
{
    public InputManager()
    {
    }
    public InputManager(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_shoot = m_Player.GetAction("shoot");
        if (m_PlayerShootActionStarted != null)
            m_Player_shoot.started += m_PlayerShootActionStarted.Invoke;
        if (m_PlayerShootActionPerformed != null)
            m_Player_shoot.performed += m_PlayerShootActionPerformed.Invoke;
        if (m_PlayerShootActionCancelled != null)
            m_Player_shoot.cancelled += m_PlayerShootActionCancelled.Invoke;
        m_Player_move = m_Player.GetAction("move");
        if (m_PlayerMoveActionStarted != null)
            m_Player_move.started += m_PlayerMoveActionStarted.Invoke;
        if (m_PlayerMoveActionPerformed != null)
            m_Player_move.performed += m_PlayerMoveActionPerformed.Invoke;
        if (m_PlayerMoveActionCancelled != null)
            m_Player_move.cancelled += m_PlayerMoveActionCancelled.Invoke;
        m_Player_special = m_Player.GetAction("special");
        if (m_PlayerSpecialActionStarted != null)
            m_Player_special.started += m_PlayerSpecialActionStarted.Invoke;
        if (m_PlayerSpecialActionPerformed != null)
            m_Player_special.performed += m_PlayerSpecialActionPerformed.Invoke;
        if (m_PlayerSpecialActionCancelled != null)
            m_Player_special.cancelled += m_PlayerSpecialActionCancelled.Invoke;
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        if (m_PlayerActionsCallbackInterface != null)
        {
            Player.SetCallbacks(null);
        }
        m_Player = null;
        m_Player_shoot = null;
        if (m_PlayerShootActionStarted != null)
            m_Player_shoot.started -= m_PlayerShootActionStarted.Invoke;
        if (m_PlayerShootActionPerformed != null)
            m_Player_shoot.performed -= m_PlayerShootActionPerformed.Invoke;
        if (m_PlayerShootActionCancelled != null)
            m_Player_shoot.cancelled -= m_PlayerShootActionCancelled.Invoke;
        m_Player_move = null;
        if (m_PlayerMoveActionStarted != null)
            m_Player_move.started -= m_PlayerMoveActionStarted.Invoke;
        if (m_PlayerMoveActionPerformed != null)
            m_Player_move.performed -= m_PlayerMoveActionPerformed.Invoke;
        if (m_PlayerMoveActionCancelled != null)
            m_Player_move.cancelled -= m_PlayerMoveActionCancelled.Invoke;
        m_Player_special = null;
        if (m_PlayerSpecialActionStarted != null)
            m_Player_special.started -= m_PlayerSpecialActionStarted.Invoke;
        if (m_PlayerSpecialActionPerformed != null)
            m_Player_special.performed -= m_PlayerSpecialActionPerformed.Invoke;
        if (m_PlayerSpecialActionCancelled != null)
            m_Player_special.cancelled -= m_PlayerSpecialActionCancelled.Invoke;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        var PlayerCallbacks = m_PlayerActionsCallbackInterface;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
        Player.SetCallbacks(PlayerCallbacks);
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Player
    private InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private InputAction m_Player_shoot;
    [SerializeField] private ActionEvent m_PlayerShootActionStarted;
    [SerializeField] private ActionEvent m_PlayerShootActionPerformed;
    [SerializeField] private ActionEvent m_PlayerShootActionCancelled;
    private InputAction m_Player_move;
    [SerializeField] private ActionEvent m_PlayerMoveActionStarted;
    [SerializeField] private ActionEvent m_PlayerMoveActionPerformed;
    [SerializeField] private ActionEvent m_PlayerMoveActionCancelled;
    private InputAction m_Player_special;
    [SerializeField] private ActionEvent m_PlayerSpecialActionStarted;
    [SerializeField] private ActionEvent m_PlayerSpecialActionPerformed;
    [SerializeField] private ActionEvent m_PlayerSpecialActionCancelled;
    public struct PlayerActions
    {
        private InputManager m_Wrapper;
        public PlayerActions(InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @shoot { get { return m_Wrapper.m_Player_shoot; } }
        public ActionEvent shootStarted { get { return m_Wrapper.m_PlayerShootActionStarted; } }
        public ActionEvent shootPerformed { get { return m_Wrapper.m_PlayerShootActionPerformed; } }
        public ActionEvent shootCancelled { get { return m_Wrapper.m_PlayerShootActionCancelled; } }
        public InputAction @move { get { return m_Wrapper.m_Player_move; } }
        public ActionEvent moveStarted { get { return m_Wrapper.m_PlayerMoveActionStarted; } }
        public ActionEvent movePerformed { get { return m_Wrapper.m_PlayerMoveActionPerformed; } }
        public ActionEvent moveCancelled { get { return m_Wrapper.m_PlayerMoveActionCancelled; } }
        public InputAction @special { get { return m_Wrapper.m_Player_special; } }
        public ActionEvent specialStarted { get { return m_Wrapper.m_PlayerSpecialActionStarted; } }
        public ActionEvent specialPerformed { get { return m_Wrapper.m_PlayerSpecialActionPerformed; } }
        public ActionEvent specialCancelled { get { return m_Wrapper.m_PlayerSpecialActionCancelled; } }
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                shoot.cancelled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                move.cancelled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                special.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpecial;
                special.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpecial;
                special.cancelled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpecial;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                shoot.started += instance.OnShoot;
                shoot.performed += instance.OnShoot;
                shoot.cancelled += instance.OnShoot;
                move.started += instance.OnMove;
                move.performed += instance.OnMove;
                move.cancelled += instance.OnMove;
                special.started += instance.OnSpecial;
                special.performed += instance.OnSpecial;
                special.cancelled += instance.OnSpecial;
            }
        }
    }
    public PlayerActions @Player
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new PlayerActions(this);
        }
    }
    private int m_keyboardSchemeIndex = -1;
    public InputControlScheme keyboardScheme
    {
        get

        {
            if (m_keyboardSchemeIndex == -1) m_keyboardSchemeIndex = asset.GetControlSchemeIndex("keyboard");
            return asset.controlSchemes[m_keyboardSchemeIndex];
        }
    }
    [Serializable]
    public class ActionEvent : UnityEvent<InputAction.CallbackContext>
    {
    }
}
public interface IPlayerActions
{
    void OnShoot(InputAction.CallbackContext context);
    void OnMove(InputAction.CallbackContext context);
    void OnSpecial(InputAction.CallbackContext context);
}

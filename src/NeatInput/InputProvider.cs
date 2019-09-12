﻿using NeatInput.Application.Hooking;
using NeatInput.Domain;
using NeatInput.Domain.Hooking;
using NeatInput.Hooking;

using System;

namespace NeatInput
{
    public class InputProvider : IDisposable
    {
        public delegate void InputReceivedDelegate(Input input);
        public event InputReceivedDelegate KeyboardInputReceived;
        public event InputReceivedDelegate MouseInputReceived;

        private readonly InputDevice<IKeyboardHook, KeyboardHook> _keyboard;
        private readonly InputDevice<IMouseHook, MouseHook> _mouse;

        public InputProvider()
        {
            _keyboard = new InputDevice<IKeyboardHook, KeyboardHook>();
            _keyboard.InputReceivedHandler = InputEventReceivedHandler;
            _mouse = new InputDevice<IMouseHook, MouseHook>();
            _mouse.InputReceivedHandler = InputEventReceivedHandler;

            AppDomain.CurrentDomain.ProcessExit += OnAppDomainLifetimeEnded;
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainLifetimeEnded;
        }

        private void InputEventReceivedHandler(Input input)
        {
            if (input.DeviceType == DeviceTypes.Keyboard)
                KeyboardInputReceived?.Invoke(input);
            else
                MouseInputReceived?.Invoke(input);
        }

        private void OnAppDomainLifetimeEnded(object s, dynamic e) => Dispose();

        public void Dispose()
        {
            _keyboard.Dispose();
            _mouse.Dispose();
        }
    }
}
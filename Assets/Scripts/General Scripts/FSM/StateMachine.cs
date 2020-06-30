using System;
using System.Collections.Generic;

public class StateMachine
{
   private IState _currentState;
   
   private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type,List<Transition>>();
   private List<Transition> _availableTransitions = new List<Transition>();
   private List<Transition> _anyStateTransitions = new List<Transition>();
   
   private static List<Transition> _emptyTransitions = new List<Transition>(0);

   public void StateMachineUpdate()
   {
      var transition = GetTransition();
      if (transition != null)
         SetState(transition.To);
      
      _currentState?.StateUpdate();
   }

   public void SetState(IState state)
   {
      if (state == _currentState)
         return;
      
      _currentState?.OnExit();
      _currentState = state;
      
      _transitions.TryGetValue(_currentState.GetType(), out _availableTransitions);
      if (_availableTransitions == null)
         _availableTransitions = _emptyTransitions;
      
      _currentState.OnEnter();
   }

   public void AddTransition(IState from, IState to, Func<bool> condition)
   {
      if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
      {
         transitions = new List<Transition>();
         _transitions[from.GetType()] = transitions;
      }
      
      transitions.Add(new Transition(to, condition));
   }

   public void AddAnyStateTransition(IState state, Func<bool> condition)
   {
      _anyStateTransitions.Add(new Transition(state, condition));
   }

   private class Transition
   {
      public Func<bool> Condition {get; }
      public IState To { get; }

      public Transition(IState to, Func<bool> condition)
      {
         To = to;
         Condition = condition;
      }
   }

   private Transition GetTransition()
   {
      foreach(var transition in _anyStateTransitions)
         if (transition.Condition())
            return transition;
      
      foreach (var transition in _availableTransitions)
         if (transition.Condition())
            return transition;

      return null;
   }
}
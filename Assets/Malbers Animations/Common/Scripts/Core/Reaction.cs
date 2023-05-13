﻿using System;
using UnityEngine; 


namespace MalbersAnimations.Reactions
{
    [Serializable]
   // [MovedFrom(false, null,"MalbersAnimations.Runtime",null)]
    /// <summary>Abstract Class to anything react </summary>
    public abstract class Reaction
    {
        /// <summary>Instant Reaction ... without considering Active or Delay parameters</summary>
        protected abstract bool _TryReact(Component reactor);

        /// <summary>Get the Type of the reaction</summary>
        public abstract Type ReactionType { get; }

        public void React(Component component) => TryReact(component);

        public void React(GameObject go) => TryReact(go.transform);

        [Tooltip("Temporally Enable or Disable the Reaction")]
        [HideInInspector] public bool Active = true;

        [Tooltip("The component assigned is verified. Which means is the Correct type")]
        protected Component Verified;


        /// <summary>  Checks and find the correct component to apply a reaction  </summary>  
        public Component VerifyComponent(Component component)
        {
            Component TrueComponent;

            if (ReactionType.IsAssignableFrom(component.GetType()))
            {
                TrueComponent = component;
            }
            else
            {
                TrueComponent = component.GetComponentInParent(ReactionType);

                if (TrueComponent == null)
                    TrueComponent = component.GetComponentInChildren(ReactionType);
            }

            Verified = TrueComponent; //Store if that component is verified.

            return TrueComponent;
        }

        public bool TryReact(Component component)
        {
            if (Active && component != null)
            {
                //Check if the component is the correct component.. a first time
                if (Verified == null || Verified != component)
                {
                    Verified = VerifyComponent(component);
                    if (Verified == null) return false;
                }

                return _TryReact(Verified);
            }
            return false;
        }
    }
}
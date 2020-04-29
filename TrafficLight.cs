using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternStateTrafficLight
{
    enum Light {Green, Yellow, Red}
    class TrafficLight
    {
        public Light CurrentLight { get; private set; } = Light.Green;
        private IState state = new GreenState();
        
        interface IState
        {
            IState Next(TrafficLight tl);
        }

        class ToGreenState : IState
        {
            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Green;
                return tl.GetState("GreenState");
            }
        }

        class ToRedState : IState
        {
            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Red;
                return tl.GetState("RedState");
            }
        }

        class RedState : IState
        {
            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Yellow;
                return tl.GetState("ToGreenState");
            }
        }


        class GreenState : IState
        {
            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Yellow;
                return tl.GetState("ToRedState");
            }
        }
        
        Dictionary<string, IState> dict = new Dictionary<string, IState>();
        private IState GetState(string key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            else
            {
                switch (key)
                {
                    case "ToGreenState": dict[key] = new ToGreenState(); break;
                    case "ToRedState": dict[key] = new ToRedState(); break;
                    case "GreenState": dict[key] = new GreenState(); break;
                    case "RedState": dict[key] = new RedState(); break;
                    default:
                        break;
                }
                return dict[key];
            }
        }

        public void Next()
        {
            state = state.Next(this);
        }

        public void Manual(string n)
        {
            switch (n)
            {
                case "G": CurrentLight = Light.Green; 
                    break;
                case "R": CurrentLight = Light.Red; 
                    break;
                case "Y": CurrentLight = Light.Yellow; 
                    break;
                default: Console.WriteLine("Y - yellow, R - red, G - green");
                    break;
            }
        }
    }

}

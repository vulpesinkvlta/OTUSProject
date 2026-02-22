using Code.Infrastructure._Common.Abstractions;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.Contexts
{
    public class GameContext
    {
        private List<IInit> _initables = new();
        private List<ITick> _tickables = new();
        private List<ILateTick> _lateTickables = new();
        private List<ITearDown> _tearDowns = new();

        public void AddReflection(MonoBehaviour monobeh)
        {
            if (monobeh is IInit init)
                _initables.Add(init);
            if (monobeh is ITick tick)
            {
                Debug.Log("Tick" + monobeh.name);
                _tickables.Add(tick);
            }
            if (monobeh is ILateTick lateTick)
                _lateTickables.Add(lateTick);
            if (monobeh is ITearDown tearDown)
                _tearDowns.Add(tearDown);

            Debug.Log(monobeh);
        }

        public void Initialize()
        {
            foreach (var initable in _initables)
                initable.Init();
        }

        public void Tick()
        {
            foreach (var tickable in _tickables)
                tickable.Tick();
        }

        public void Cleanup()
        {
            _initables.Clear();
            _tickables.Clear();
            _lateTickables.Clear();
            _tearDowns.Clear();
        }
    }
}
using System;
using System.Collections.Generic;

namespace KNTy.MVP.Runtime
{
    public sealed class PresenterRegistry
    {
        readonly Dictionary<ViewBase, IPresenter> _map;

        public PresenterRegistry()
        {
            _map = new Dictionary<ViewBase, IPresenter>();
        }

        public void Register(ViewBase view, IPresenter presenter)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));
            if (presenter == null) throw new ArgumentNullException(nameof(presenter));
            if (_map.ContainsKey(view)) throw new InvalidOperationException($"View already registered : {view}");

            _map.Add(view, presenter);
        }

        public bool GetPresenter<TPresenter>(ViewBase view, out TPresenter presenter) where TPresenter : IPresenter
        {
            if (_map.TryGetValue(view, out var p) && p is TPresenter typed)
            {
                presenter = typed;
                return true;
            }
            else
            {
                presenter = default;
                return false;
            }
        }

        public void Unregister(ViewBase view)
        {
            if (!_map.TryGetValue(view, out IPresenter presenter)) return;
            (presenter as IDisposable)?.Dispose();
            _map.Remove(view);
        }

        public void Clear()
        {
            foreach (var presenter in _map.Values)
            {
                (presenter as IDisposable)?.Dispose();
            }
            _map.Clear();
        }
    }
}

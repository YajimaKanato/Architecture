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

        public bool TryRegister(ViewBase view, IPresenter presenter)
        {
            if (view == null) return false;
            if (presenter == null) return false;

            return _map.TryAdd(view, presenter);
        }

        public bool TryGetPresenter<TPresenter>(ViewBase view, out TPresenter presenter) where TPresenter : IPresenter
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

        public void TryUnregister(ViewBase view)
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

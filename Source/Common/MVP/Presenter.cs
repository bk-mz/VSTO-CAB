using System;
using System.Collections.Generic;
using System.Text;

namespace WordCAB.Common.MVP
{
    /// <summary>
    /// Базовый класс для Presenter в шаблоне MVP
    /// </summary>
    /// <typeparam name="T">Интерфейс View</typeparam>
    public class Presenter<T> 
        where T : class
    {
        #region Public Properties
        private T _view;
        /// <summary>
        /// View
        /// </summary>
        public T View
        {
            get { return _view; }
            set { _view = value; OnViewSet(); }
        }
        
        #endregion

        #region Protecteds
        protected virtual void OnViewSet()
        {
        } 
        #endregion
    }
}

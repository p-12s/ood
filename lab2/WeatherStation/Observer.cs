using System.Collections.Generic;

namespace WeatherStation
{
    /*
    Are you a display and want to be notified? Implement it
    */
    interface IObserver<T>
    {
        void Update(T data); // virtual/private not valid
    }

    /*
    Signs / unsubscribes to alerts,
    Sends notifications to observers.
    */
    interface IObservable<T>
    {
        void RegisterObserver(IObserver<T> observer); // ref ? 
        void NotifyObservers();
        void RemoveObserver(IObserver<T> observer);// (IObserver<T> & observer) = 0; 
    };

    /*
    Universal classes are universal interfaces.
    It avoids packaging transformations and unpacking-transformations for value types
    */
    class CObservable<T> : IObservable<T>
    {
        public void RegisterObserver(IObserver<T> observer)
	    {
		    m_observers.Add(observer);
	    }

        public void NotifyObservers()
	    {
		    T data = GetChangedData();
            // auto clone(m_observers); // Cloning as a solution of problem 2
            foreach (var observer in m_observers)
            {
                observer.Update(data);
            }
        }

        public void RemoveObserver(IObserver<T> observer)
	    {
		    m_observers.Remove(observer);
	    }

        protected virtual T GetChangedData()
        {
            return default(T);
        }

        private HashSet<IObserver<T>> m_observers = new HashSet<IObserver<T>>();
    }
}


using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    /// <summary>
    /// A simple Injection container
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Dictionary to store interface and implementation types
        /// </summary>
        private Dictionary<Type, Type> _bindings = new Dictionary<Type, Type>();

        /// <summary>
        /// Store an interface and implementation type
        /// </summary>
        /// <param name="interfaceType">Type of interface</param>
        /// <param name="implementationType">Implementation</param>
        public void Bind(Type interfaceType, Type implementationType) 
        {
         if(!_bindings.ContainsKey(interfaceType))
         {
             _bindings.Add(interfaceType, implementationType);
         }
         else
         {
             _bindings[interfaceType] = implementationType;
         }
        }

        /// <summary>
        /// Get an instance of a type
        /// </summary>
        /// <typeparam name="T">Type of instance to get</typeparam>
        /// <returns></returns>
        public T Get<T>()
        {
            return (T)Activator.CreateInstance(_bindings[typeof(T)]);
        }
    }
}
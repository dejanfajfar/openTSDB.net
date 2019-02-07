using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using OpenTsdbNet.models;
using OpenTsdbNet.Network;

namespace OpenTsdbNet
{
    /// <summary>
    /// Implements factory facility to create <see cref="OpenTsdbManager"/> instance
    /// </summary>
    public static class OpenTsdbFactory
    {
        private static IOpenTsdbManager instance;

        private static readonly IDictionary<string, IOpenTsdbManager> namedInstances;

        static OpenTsdbFactory()
        {
            namedInstances = new ConcurrentDictionary<string, IOpenTsdbManager>();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="IOpenTsdbManager"/>
        /// </summary>
        /// <param name="options"></param>
        /// <returns>A new instance of </returns>
        public static IOpenTsdbManager Instance(TsdbOptions options) => new OpenTsdbManager(options, new OpenTsdbIntegration(options.OpenTsdbServerUri));


        /// <summary>
        /// Creates or returns an already existing instance of <see cref="IOpenTsdbManager"/>
        /// </summary>
        /// <param name="options">The options needed to initialize a new instance</param>
        /// <param name="instanceName">The name of the instance</param>
        /// <returns>
        ///    If the name is not known then a new instance will be returned. If the name has already an instance created then that instance will be returned
        /// </returns>
        /// <exception cref="ArgumentException">
        ///    If the instance name is null or made up completely of whitespaces 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///    If the options are needed to create a new instance and are found to be null
        /// </exception>
        public static IOpenTsdbManager Instance(TsdbOptions options, string instanceName)
        {
            if (string.IsNullOrWhiteSpace(instanceName))
            {
                throw new ArgumentException(ErrorMessages.NAMED_MANAGER_INSTANCE_NAME_INVALID, nameof(instanceName));
            }

            if (!namedInstances.ContainsKey(instanceName))
            {
                if (options == null)
                {
                    throw new ArgumentNullException(ErrorMessages.MANAGER_OPTIONS_NULL, nameof(options));
                }
                
                namedInstances[instanceName] = Instance(options);    
            }
            
            return namedInstances[instanceName];
        }

        /// <summary>
        /// Clears all registered named instances of the <see cref="IOpenTsdbManager"/>
        /// </summary>
        public static void ClearNamed()
        {
            namedInstances.Clear();
        }

        /// <summary>
        /// Determines if a named instance is already registered
        /// </summary>
        /// <param name="instanceName">The name of the queried instance</param>
        /// <returns>True if the instance is already registered, False if otherwise</returns>
        public static bool IsInstanceDefined(string instanceName)
        {
            return !string.IsNullOrWhiteSpace(instanceName) && namedInstances.ContainsKey(instanceName);
        }
    }
}
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using OpenTsdbNet;
using OpenTsdbNet.models;
using OpenTsdbNet.Network;

namespace openTSDB.net
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
        /// <param name="options">The options to create the openTsdbManager with</param>
        /// <returns>A new instance of </returns>
        public static IOpenTsdbManager CreateNew(TsdbOptions options) => new OpenTsdbManager(options, new OpenTsdbIntegration(options.OpenTsdbServerUri));

        /// <summary>
        /// Retrieves a singelton instance of the <see cref="IOpenTsdbManager"/>
        /// </summary>
        /// <param name="options">The startup options</param>
        /// <returns>A shared singelton instance of the <see cref="IOpenTsdbManager"/></returns>
        public static IOpenTsdbManager GetSingleton(TsdbOptions options)
        {
            return instance ?? (instance = new OpenTsdbManager(options, new OpenTsdbIntegration(options.OpenTsdbServerUri)));
        }

        /// <summary>
        /// Creates a new named instance of the <see cref="IOpenTsdbManager"/> implementation
        /// </summary>
        /// <param name="name">The unique name of the initialized instance</param>
        /// <param name="options">The startup options for the named instance</param>
        /// <returns>The newly created named instance of the <see cref="IOpenTsdbManager"/></returns>
        /// <exception cref="ArgumentException">
        /// A <see cref="ArgumentException"/> is shown if
        /// * The provided name is null or conists only of whitespaces
        /// * The provided name is already alocated in the named instance repository
        /// * The provided options are null
        /// </exception>
        public static IOpenTsdbManager CreateNamed(string name, TsdbOptions options)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ErrorMessages.NAMED_MANAGER_INSTANCE_NAME_INVALID, nameof(name));
            }

            if (options == null)
            {
                throw new ArgumentNullException(ErrorMessages.MANAGER_OPTIONS_NULL, nameof(options));
            }

            if (namedInstances.ContainsKey(name))
            {
                throw new ArgumentException(ErrorMessages.NAMED_MANAGER_INSTANCE_ALREADY_REGISTERED, nameof(name));
            }
            
            namedInstances[name] = CreateNew(options);

            return GetNamed(name);
        }

        /// <summary>
        /// Retrieves a previously created named instance of the <see cref="IOpenTsdbManager"/>
        /// </summary>
        /// <param name="name">The name of the requested instance</param>
        /// <returns>The named <see cref="IOpenTsdbManager"/> instance</returns>
        /// <exception cref="ArgumentException">
        /// Thorwn if the provided name is null or consist only of whitespaces
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        /// If the desired named instance has not been initialized yet
        /// </exception>
        public static IOpenTsdbManager GetNamed(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ErrorMessages.NAMED_MANAGER_INSTANCE_NAME_INVALID, nameof(name));
            }

            if (!namedInstances.ContainsKey(name))
            {
                throw new KeyNotFoundException();
            }

            return namedInstances[name];
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
        /// <param name="name">The name of the queried instance</param>
        /// <returns>True if the instance is already registered, False if otherwise</returns>
        public static bool IsNamedDefined(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && namedInstances.ContainsKey(name);
        }
    }
}